using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous
{
    public class AsyncVoidMethod
    {
        public async void DelayTaskWithWithExeption()
        {

            await Task.Run(() =>
            {
                throw new InvalidOperationException("Test Async Void");
            });



        }

        public async Task TestAsyncVoid()
        {
            try
            {
                var asyncVoid = new AsyncVoidMethod();
                //the exeption is lost here
                 asyncVoid.DelayTaskWithWithExeption();
            }
            catch (System.Exception)
            {
                // any exception is thrown even when we are throwing one.
                throw;
            }

        }


    }
}