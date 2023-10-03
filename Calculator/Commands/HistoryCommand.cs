namespace CalculatorApp;

class HistoryCommand : Command
{
    public static bool ParseCommand(List<ParseToken> tokens, out Command? command)
    {
        if (tokens.Count == 1
            && tokens[0].Type == TokenType.Name
            && tokens[0].Value == "history")
        {
            command = new HistoryCommand(tokens);
            return true;
        }
        else
        {
            command = null;
            return false;
        }
    }

    public HistoryCommand(List<ParseToken> tokens) : base(tokens) { }

    public override void Execute(History history, out bool isExit)
    {
        isExit = false;

        foreach (Command command in history.GetHistory())
        {
            Console.WriteLine(command);
        }
    }
}
