using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous{
    public class SyncronizationContexTest
    {
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