using System;

namespace ConcurrencyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Delay
            var progress = new Progress<int>();
            var count = new ProgressLab();
            progress.ProgressChanged += (sender, args) =>
            {
                Console.WriteLine("Hola");
            };
            count.Counter(progress).GetAwaiter();
        }
    }
}
