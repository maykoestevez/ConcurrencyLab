using System;
using System.Threading;
using System.Threading.Tasks;
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

        private Task TestSC()
        {
            var task = Task.Delay(TimeSpan.FromSeconds(2));
            var currentSyncContext = SynchronizationContext.Current;

            task.ContinueWith(delegate
            {
                if (currentSyncContext == null) Console.WriteLine("After await task");
                else currentSyncContext.Post(delegate { Console.WriteLine("After await task"); }, null);

            }, TaskScheduler.Current);

            return Task.CompletedTask;
        }
        private async Task SomethingAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("After await task");
        }
    }
}
