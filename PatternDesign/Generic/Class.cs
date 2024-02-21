using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Classes
    {
        public void Main()
        {
            ParametrosEnClass pair = new ParametrosEnClass<int, string>(10, "Hola");
            
            // Public --> la clase puede ser utilizada en cualquier proyecto.
            // Private --> la clase sólo puede usarse en el módulo en la que está definida.
            Internal internalClass = new Internal();
            Protected protectedClass = new Protected();
            ProtectedInternal protectedInternal = new ProtectedInternal();
            AbstractClass abstractClass = new AbstractClass();
            SealedClass sealedClass = new SealedClass();  
        }
    }

    public class ParametrosEnClass<TFirst, TSecond> {

        // Esto es una clase generica

        // La clase ParametrosEnClass<TFirst, TSecond> es una clase genérica que toma dos parámetros 
        // de tipo, TFirst y TSecond. Esto significa que la clase puede trabajar con cualquier tipo 
        // de datos que se especifique cuando se crea una instancia de la clase.

        public TFirst First { get; }
        public TSecond Second { get; }
    
        // Es un get con arrow 
        public Pair(TFirst first, TSecond second) => 
            (First, Second) = (first, second);

        // Crear una instancia, pasandole parametros
        var pair = new ParametrosEnClass<int, string>(10, "Hola");
        Console.WriteLine($"First: {pair.First}, Second: {pair.Second}");
    }
    
    public internal class Internal () {

        public class Main () {
            // la clase está limitada al proyecto en el cual está definida
            // Tiene que ver mucho con las .dll
        }

        class Example () {

            // Assembly2.cs  
            // Compile with: /target:library  
            public class BaseClass
            {  
                internal static int intM = 0;  
            }  

            // Assembly2_a.cs  
            // Compile with: /reference:Assembly2.dll  
            public class TestAccess
            {  
                static void Main()
                {  
                    var myBase = new BaseClass();   // Ok.  
                    BaseClass.intM = 444;    // CS0117  
                }  
            }  
        }
    }

    public protected class Protected () {
        public class Main () {
            // la clase sólo puede ser utilizada en una subclase. Es decir sólo se puede utilizar protected para una clase declarada en otra clase.
        }


        class Example () {

            // Definición Base
            public class Outer
            {
                protected class Foo
                {
                }
            }

            class X 
            {
                // 'Outer.Foo' is inaccessible due to its protection level
                private void Flibble(Outer.Foo foo)
                {

                }
            }

            class X : Outer
            {
                // fine
                private void Flibble(Outer.Foo foo)
                {

                }
            }
        }
    }

    public protected internal class ProtectedInternal () {
        
    }

    public abstract class AbstractClass
    {
        public abstract void Main()
        {
            // No se pueden crear instancias de una clase abstracta. 

            // El propósito de una clase abstracta es proporcionar una definición común de una 
            // clase base que múltiples clases derivadas pueden compartir. Por ejemplo, una biblioteca de clases puede
            // definir una clase abstracta que se utiliza como parámetro para muchas de sus funciones y solicitar 
            // a los programadores que utilizan esa biblioteca que proporcionen su propia implementación de la clase 
            // mediante la creación de una clase derivada.
        }

        public class Example {

            public class D
            {
                public virtual void DoWork(int i)
                {
                    // Original implementation.
                }
            }

            public abstract class E : D
            {
                public abstract override void DoWork(int i);
            }

            public class F : E
            {
                public override void DoWork(int i)
                {
                    // New implementation.
                }
            }
        }
    }

    public sealed class SealedClass {

        public abstract void Main()
        {
            // No se puede heredar
            // No puede ser una clase abstracta. 
            // No puede se puede utilizar como clase base
            // Puesto que nunca se pueden utilizar como clase base, algunas optimizaciones en tiempo de ejecución pueden hacer que sea un poco más rápido llamar a miembros de clase sellada. 
        }

        public class Example {

            // -------------------- PRIMERA FASE SIN SEALED --------------------
            class Vehiculo
            {
                //Código
            }

            class Coche : Vehiculo 
            {
                //Código
            }

            class Moto : Vehiculo
            {
                //Código
            }

            class Furgoneta : Coche {} // Funciona pero no es logico
            class Furgon : Coche {} // Funciona pero no es logico
            class Turismo : Coche {} // Funciona pero no es logico


            // -------------------- SEGUNDA FASE SIN SEALED --------------------

            sealed class Coche : Vehiculo
            {
                //Código
            }

            sealed class Moto : Vehiculo
            {
                //Código
            }

            class Furgoneta : Coche { } //Error
            class Furgon : Coche { } //Error
            class Turismo : Coche { } //Error
        }
    }
}