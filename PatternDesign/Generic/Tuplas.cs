

using System.Text;
using System.Threading.Tasks;

namespace Tuplas
{ 
    class Tuplas {

        public void Main() {
            
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
            //Output:
            //Sum of 3 elements is 4.5.

        }
    }

}