using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ConcurrencyLab
{
    public class Iterators
    {
        public void ParallelFor()=>
                       Parallel.For(0, 9, (index) =>{ /*Parralel work should be independent*/ });
        

        public void ParallelForEach()=>
                 Parallel.ForEach(Enumerable.Range(0, 10), (data) =>{ /*Parralel work should be independent*/});
        
    }
}