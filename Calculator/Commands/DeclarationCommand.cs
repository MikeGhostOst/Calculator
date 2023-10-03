namespace CalculatorApp;

class DeclarationCommand : Command
{
    public static bool ParseCommand(List<ParseToken> tokens, History history, out Command? command)
    {
        if (tokens.Count != 3)
        {
            command = null;
            return false;
        }

        bool isVariable = tokens[0].Type == TokenType.Name;
        bool isAssignment = tokens[1].Type == TokenType.Operator
                         && tokens[1].Value == "=";
        bool isValue = tokens[2].Type == TokenType.Number
            || tokens[2].Type == TokenType.Name && history.HasVariable(tokens[2].Value);

        if (isVariable && isAssignment && isValue)
        {
            command = new DeclarationCommand(tokens);
            return true;
        }
        else
        {
            command = null;
            return false;
        }
    }

    public DeclarationCommand(List<ParseToken> tokens) : base(tokens) { }

    public override void Execute(History history, out bool isExit)
    {
        isExit = false;

        string varName = _tokens[0].Value;
        ParseToken valueToken = _tokens[2];

        if (valueToken.Type == TokenType.Name)
        {
            int value = history.GetVariableValue(valueToken.Value);
            history.SetVariable(varName, value);
        }
        else if (valueToken.Type == TokenType.Number)
        {
            history.SetVariable(varName, int.Parse(valueToken.Value));
        }

        Console.WriteLine($"Variable \"{varName}\" is set.");
    }
}
