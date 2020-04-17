using System;
using System.Threading;
using System.Threading.Tasks;
using ConcurrencyLab.Asynchronous;

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
