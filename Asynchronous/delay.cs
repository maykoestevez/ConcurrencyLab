using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous
{
    public class Delay<T>
    {
        public async Task<T> DelayTask(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }
        public async Task<string> WebRequestTimeOutTask(HttpClient httpClient, string url)
        {
            
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
            {
                
                var downloadTask = httpClient.GetStringAsync(url);
                var timeOutTask = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);

                var completedTask = await Task.WhenAny(downloadTask, timeOutTask);

                if (completedTask == timeOutTask)
                {
                    return null;
                }

                return await downloadTask;

            }

        }
    }
}