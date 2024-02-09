using PatternDesign;

Utils utils = new Utils();

Utils.WriteConsole writeConsole = utils.writeConsole;
Utils.AnotherThings anotherThings = utils.anotherThings; // Example

writeConsole.WriteIntro();
writeConsole.WriteInfo("This is my project for study pattern design.");


writeConsole.WriteInfo("Now I'm executing the Factory Method.");
new FactoryMethod().Main();


writeConsole.WriteInfo("End of execute the project PatternDesign.", true);



