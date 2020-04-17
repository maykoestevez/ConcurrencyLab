using System;
using System.Threading.Tasks;

namespace ConcurrencyLab.Asynchronous
{
    public class ProgressLab
    {
        public Task Counter(IProgress<int> progress = null)
        {
            var done = false;

            while (!done)
            {
                for (int i = 1; i <= 100; i++)
                {
                    progress.Report(i);

                }

                done = true;

            }
            return Task.CompletedTask;
        }
    }
}