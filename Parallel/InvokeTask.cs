using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ConcurrencyLab
{
    public class InvokeTask
    {
        public void ParallelInvoke()=> 
                  Parallel.Invoke(() => {},() =>{});
        
    }
}