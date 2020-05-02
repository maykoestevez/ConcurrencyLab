using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous
{
    public class WhenAny
    {
        // Should return a task when all of then finish
        public async Task<string> DoWhenAny()
        {

            var task1 = Task.Delay(TimeSpan.FromSeconds(1));
            var task2 = Task.Delay(TimeSpan.FromSeconds(2));

            // return a completed task even if some of the task fail
            var resultTask = await Task.WhenAny(task1, task2);
            
            await resultTask;

            if (resultTask == task1)
            {
                
                return "Task1 finish first";
            }

            return "Task2 finish first";

        }
    }
}