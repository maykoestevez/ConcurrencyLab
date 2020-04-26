using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ConcurrencyLab
{
    public class Iterators
    {
        public void ParallelFor()=>
                       Parallel.For(0, 9, (index) =>{ /*parralel work should be independent*/ });

        public void ParallelForEach()=>
                 Parallel.ForEach(Enumerable.Range(0, 10), (data) =>{ /*parralel work should be independent*/});
    }
}