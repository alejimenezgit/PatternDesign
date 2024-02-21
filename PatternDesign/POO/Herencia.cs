using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.POO
{
    internal class Herencia
    {

        // HERENCIA VS INTERFACE

        // Todo lo definido en una interfaz va a tener que ser implementado en la clase, pero en la herencia, podemos designar 
        // cuales miembros se heredan y cuales no y podemos definir si hay miembros que pueden ser alterados por los hijos


        class Example() {
            public abstract class Transporte
            {
                public sealed void Mover()
                {
                    Console.WriteLine("Moviendo {0} ruedas", Ruedas);
                }
            
                public abstract int Ruedas { get; }
            }
            
            public class Coche : Transporte
            {
                public override int Ruedas
                {
                    get { return 4; }
                }
            }
            
            public class Bicicleta : Transporte
            {
                public override int Ruedas
                {
                    get { return 2; }
                }
            }
        }


    }
}
