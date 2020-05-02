using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous
{
    public interface IFromResult
    {
        Task<string> GetName();
    }
    public class FromResult : IFromResult
    {

        // In this case yuo don't need any async task to run
        public Task<string> GetName()
        {
            return Task.FromResult("Mayko");
        }
        // What if you get a exception
        public Task RunProcessWithException()
        {
            try
            {
                throw new InvalidOperationException("Error");
            }
            catch (System.Exception ex)
            {

                return Task.FromException(ex);
            }

        }

        // If the task is cancelled
        public Task<string> CancelledTask(CancellationToken token)
        {
             if (token.IsCancellationRequested)
                return Task.FromCanceled<string>(token);
            return Task.FromResult("Mayko");    
        }

    }
}