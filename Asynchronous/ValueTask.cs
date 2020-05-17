using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous
{
    public class ValueTask
    {
        // Adventage, Return Value in an async environment and mix async with sync process 
        // and save allocation in memory so it improve performnace
        // Disadventage you can just await it once.
        public async ValueTask<int> delay(TimeSpan time)
        {
            await Task.Delay(time);
            return 20;
        }

        // Value task as task
        public async Task TestDelay()
        {
            var convertToTask = delay(TimeSpan.FromSeconds(2)).AsTask();
            await convertToTask;
        }
    }
}