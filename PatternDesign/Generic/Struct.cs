using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    class Struct
    {
        public void Main()
        {
            // Las structs, tienen como objetivo estructurar algunos 
            // datos comunes dentro de un mismo contexto, algo muy similar a la idea de clases
            

            // Struct
            // 1 Las estructuras son tipos de valores asignados en la pila o en línea en los tipos que los contienen. 
            // 2 Las asignaciones y desasignaciones de tipos de valor son, en general, más baratas que las asignaciones y desasignaciones de tipos de referencia. 
            // 3 En las estructuras, cada variable contiene su propia copia de los datos (excepto en el caso de las variables de parámetro ref y out), y una operación en una variable no afecta a otra variable. 

            // VS

            // Class
            // 1. Las clases son tipos de referencia, asignados en el montón y recolectados como basura.
            // 2. Las asignaciones de tipos de referencia grandes son más económicas que las asignaciones de tipos de valores grandes.
            // 3. En las clases, dos variables pueden contener la referencia del mismo objeto y cualquier operación sobre una variable puede afectar a otra variable.


            // De esta manera, struct debe usarse solo cuando esté seguro de que:
            // - Lógicamente representa un valor único, como los tipos primitivos (int, double, etc.).
            // - Es inmutable.
            // - No se debe empaquetar y desembalar con frecuencia.
        }

        public class CombinacionDiferentesTipos () {

            struct Direccion {
                public int codPostal;
                public string calle;
                public string ciudad; 
                public string getDireccion(){
                    return calle + "\r\n " + codigoPostal + "\t"+ ciudad.ToUpper(); 
                }
            }

            // fijarse en el tipo de dato del campo correoPostal
            struct Cliente {
                public int codigo;
                public string apellido;
                public string nombre;
                public string email; 
                public Direccion correoPostal
            }

            Cliente UnCliente;
            UnCliente.codigo = 9999;
            UnCliente.apellido = "Pedraza";
            UnCliente.nombre = "Juanjo";
            UnCliente.correoPostal.codPostal=3740;
            UnCliente.correoPostal.calle="C/ Perico Palotes, 33";
            UnCliente.correoPostal.ciudad="Gata de Gorgos City";

        }
    
        public class Example () {
            struct Location
            {
                public int x, y;

                public Location(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }

            class Program
            {
                static void Main(string[] args)
                {
                    Location a = new Location(20, 20);
                    Location b = a;
                    a.x = 100;

                    // Print the value of b.x
                    Console.WriteLine(b.x);

                    // Output: 20
                }
            }
        }
    }
}