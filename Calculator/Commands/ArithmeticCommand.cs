namespace CalculatorApp;

class ArithmeticCommand : Command
{
    public static bool ParseCommand(List<ParseToken> tokens, History history, out Command? command)
    {
        if (tokens.Count < 3 || tokens.Count % 2 == 0)
        {
            command = null;
            return false;
        }

        for (int i = 0; i < tokens.Count; i++)
        {
            bool isOperandIndex = i % 2 == 0;

            bool isValidToken =
                isOperandIndex && _isOperand(tokens[i], history)
                || !isOperandIndex && _isOperator(tokens[i]);

            if (!isValidToken)
            {
                command = null;
                return false;
            }
        }

        command = new ArithmeticCommand(tokens);
        return true;
    }

    static bool _isOperand(ParseToken token, History history)
    {
        return token.Type == TokenType.Number
            || token.Type == TokenType.Name && history.HasVariable(token.Value);
    }

    static bool _isOperator(ParseToken token)
    {
        if (token.Type != TokenType.Operator)
        {
            return false;
        }

        return token.Value == "/"
            || token.Value == "*"
            || token.Value == "+"
            || token.Value == "-";
    }

    static int _getOperandValue(ParseToken token, History history)
    {
        if (token.Type == TokenType.Number)
        {
            return int.Parse(token.Value);
        }
        else
        {
            return history.GetVariableValue(token.Value);
        }
    }

    public ArithmeticCommand(List<ParseToken> tokens) : base(tokens) { }

    public override void Execute(History history, out bool isExit)
    {
        isExit = false;

        int result = _getOperandValue(_tokens[0], history);

        for (int i = 1; i < _tokens.Count - 1; i += 2)
        {
            string arithOperator = _tokens[i].Value;
            int operand = _getOperandValue(_tokens[i + 1], history);

            if (arithOperator == "+")
            {
                result += operand;
            }
            else if (arithOperator == "-")
            {
                result -= operand;
            }
            else if (arithOperator == "*")
            {
                result *= operand;
            }
            else if (arithOperator == "/")
            {
                result /= operand;
            }
        }

        Console.WriteLine($"Result: {result}");
    }
}
