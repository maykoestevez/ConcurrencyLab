using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous
{
    public class WhenAll
    {
        // Should return a task when all of then finish
        public  async Task DoWhenAll()
        {

            var task1 = Task.Delay(TimeSpan.FromSeconds(1));
            var task2 = Task.Delay(TimeSpan.FromSeconds(2));
            var task3 = Task.Delay(TimeSpan.FromSeconds(3));

             await Task.WhenAll(task1, task2, task3);
        }
    }
}