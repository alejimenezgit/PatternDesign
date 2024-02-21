using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.POO
{
    internal class Abstraccion
    {
        // En C#, la abstracción es un concepto fundamental de la programación orientada a objetos que permite definir un conjunto 
        // de características esenciales y comunes a un grupo de objetos, independientemente de su implementación específica.

        class Example () {

            public abstract class Vehicle
            {
                public int MaxSpeed { get; set; }
                public int Acceleration { get; set; }

                public abstract void Move();
            }

            public class Car : Vehicle
            {
                public override void Move()
                {
                    Console.WriteLine("The car is moving");
                }
            }

            public class Bike : Vehicle
            {
                public override void Move()
                {
                    Console.WriteLine("The bike is moving");
                }
            }
        }
    }
}
