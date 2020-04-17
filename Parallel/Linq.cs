using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcurrencyLab
{
    public class Linq
    {
       IEnumerable<int> TestPLinq()=> 
                    Enumerable.Range(0, 10).AsParallel().Select(value=>value);
    }
}