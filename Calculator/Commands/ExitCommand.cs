namespace CalculatorApp;

class ExitCommand : Command
{
    public static bool ParseCommand(List<ParseToken> tokens, out Command? command)
    {
        if (tokens.Count == 1
            && tokens[0].Type == TokenType.Name
            && tokens[0].Value == "exit")
        {
            command = new ExitCommand(tokens);
            return true;
        }
        else
        {
            command = null;
            return false;
        }
    }

    public ExitCommand(List<ParseToken> tokens) : base(tokens) { }

    public override void Execute(History history, out bool isExit)
    {
        isExit = true;
        Console.WriteLine("Exiting the calculator...");
    }
}
