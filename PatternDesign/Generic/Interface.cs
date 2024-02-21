using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Interface
    {
        public void Main()
        {
            // Una interfaz define un contrato que se puede implementar mediante 
            // clases y structs. Una interfaz se define para declarar capacidades 
            // que se comparten entre tipos distintos. Por ejemplo, la interfaz
            
            HerenciaMultiple();
        }

        public class HerenciaMultiple {

            interface IControl
            {
                void Paint();
            }

            interface ITextBox : IControl
            {
                void SetText(string text);
            }

            interface IListBox : IControl
            {
                void SetItems(string[] items);
            }

            interface IComboBox : ITextBox, IListBox { }
        }
    }
}