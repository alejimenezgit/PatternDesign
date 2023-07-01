namespace PatternDesign
{
    public class Utils
    {
        public WriteConsole writeConsole;
        public AnotherThings anotherThings;

        // That is a constructor
        public Utils()
        {
            writeConsole = new WriteConsole();
            anotherThings = new AnotherThings(); // Ejemplo de otras cosas
        }

        public class WriteConsole
        {
            public WriteConsole() { }

            public void WriteInfo(string textInfo, bool endProject = false)
            {
                if (endProject) JumpLine();
                WriteLines();
                Console.WriteLine(textInfo);
                WriteLines();
                JumpLine();
            }

            public void WriteIntro()
            {
                Console.Clear();
                Console.Title = "Patter Design";
            }

            private void JumpLine()
            {
                Console.WriteLine("\r\n");
            }

            private void WriteLines()
            {
                Console.WriteLine("--------------------------------------------");
            }
        }

        public class AnotherThings
        {
            public AnotherThings() { }
        }
    }
}
