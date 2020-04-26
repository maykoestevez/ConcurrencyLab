
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConcurrencyLab.DataFlow
{
    public class Pipeline
    {
        /*
        Creating a pipe line with DataFlow That download  text from url
         and print the word with the reverse value found in the text
        1. Download text from url
        2. Create a list of words
        3. Filter data in the text
        4. Find reverse words
        5. Print reverse words
        */
        public Task CreatePipeline()
        {

            //
            // Create the members of the pipeline.
            //

            // Downloads the requested resource as a string.
            var downloadString = new TransformBlock<string, string>(async uri =>
            {
                Console.WriteLine("Downloading String {0}", uri);
                return await new HttpClient().GetStringAsync(uri);
            });

            var createWordList = new TransformBlock<string, string[]>(text =>
            {
                Console.WriteLine("Creating word list");

                //remove not letters characters
                var tokens = text.Select(c => char.IsLetter(c) ? c : ' ').ToArray();
                text = new string(tokens);

                // Create an array of letters without space
                return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            });

            var filterWordList = new TransformBlock<string[], string[]>(words =>
            {
                Console.WriteLine("Filtering word list...");

                return words
                      .Where(w => words.Length > 3)
                      .Distinct()
                      .ToArray();
            });

            // Looking for the reverse word whose reverse word also exists in the collections
            var findReverseWord = new TransformManyBlock<string[], string>(words =>
            {
                Console.WriteLine("Finding reversed words...");

                var wordSet = new HashSet<string>(words);

                return from word in words.AsParallel()
                       let reverse = new string(word.Reverse().ToArray())
                       where word != reverse && wordSet.Contains(reverse)
                       select word;
            });

            // Print words with the reverse found
            var printReverseWords = new ActionBlock<string>(reverseWords =>
            {
                Console.WriteLine("Found reversed words {0}/{1}",
                        reverseWords, reverseWords.Reverse().ToArray());

            });

            //Build pipeline

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            downloadString.LinkTo(createWordList, linkOptions);
            createWordList.LinkTo(filterWordList, linkOptions);
            filterWordList.LinkTo(findReverseWord, linkOptions);
            findReverseWord.LinkTo(printReverseWords, linkOptions);

            downloadString.Post("http://www.gutenberg.org/cache/epub/16452/pg16452.txt");

            downloadString.Complete();
            printReverseWords.Completion.Wait();
           
           return Task.CompletedTask;

        }
    }
}