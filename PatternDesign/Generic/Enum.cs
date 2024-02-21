using System.Text;
using System.Threading.Tasks;

namespace Enum
{ 
    class Enum {

        public void Main() {
            
            [Flags]  // Se pone Flags para identificar que All contiene todos con el seperador OR
            public enum Seasons
            {
                None = 0,
                Summer = 1,
                Autumn = 2,
                Winter = 4,
                Spring = 8,
                All = Summer | Autumn | Winter | Spring
            }

        }
    }

}