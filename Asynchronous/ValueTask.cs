using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous
{
    public class ValueTask
    {
        // Adventage, Return Value in an async environment and mix async with sync process
        // Disadventage you can just await it once
        public async ValueTask<int> delay(TimeSpan time)
        {
            await Task.Delay(time);
            return 20;
        }
    }
}