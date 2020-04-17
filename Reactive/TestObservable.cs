using System;
using System.Diagnostics;
using System.Reactive.Linq;

namespace ConcurrencyLab
{
    public class TestObservable
    {
        public void Test()
        {
         IObservable<DateTimeOffset> timestamps = 
         Observable.Interval(TimeSpan.FromSeconds(1))
                .Timestamp()
                .Where(x=>x.Value % 2==0)
                .Select(x=>x.Timestamp);

           timestamps.Subscribe(x=> Trace.WriteLine(x));     
        }
    }
}