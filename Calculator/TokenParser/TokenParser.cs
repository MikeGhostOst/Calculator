namespace CalculatorApp;

static class TokenParser
{
    public static List<ParseToken> Parse(string userInput)
    {
        string separatedUserInput = _separateOperators(userInput);

        List<string> substrings = separatedUserInput
            .Split(' ')
            .Where(str => str != String.Empty)
            .ToList();

        List<ParseToken> tokens = new List<ParseToken>();
        foreach (string substring in substrings)
        {
            ParseToken token = new ParseToken()
            {
                Value = substring,
                Type = _getTokenType(substring)
            };

            tokens.Add(token);
        }
        return tokens;
    }

    static TokenType _getTokenType(string str)
    {
        if (_isNumber(str))
        {
            return TokenType.Number;
        }
        else if (_isName(str))
        {
            return TokenType.Name;
        }
        else if (_isOperator(str))
        {
            return TokenType.Operator;
        }
        else
        {
            return TokenType.None;
        }
    }

    static string _separateOperators(string userInput)
    {
        string separatedUserInput = "";

        for (int i = 0; i < userInput.Length; i++)
        {
            if (_isOperator(userInput[i]))
            {
                separatedUserInput += $" {userInput[i]} ";
            }
            else
            {
                separatedUserInput += userInput[i];
            }
        }

        return separatedUserInput;
    }

    static bool _isOperator(char c)
    {
        return c == '+'
            || c == '-'
            || c == '/'
            || c == '*'
            || c == '=';
    }

    static bool _isOperator(string str)
    {
        if (str.Length != 1)
        {
            return false;
        }
        else
        {
            return _isOperator(str[0]);
        }
    }

    static bool _isName(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (i == 0 && Char.IsDigit(str[i]))
            {
                return false;
            }

            if (!Char.IsLetterOrDigit(str[i]))
            {
                return false;
            }
        }

        return true;
    }

    static bool _isNumber(string str)
    {
        foreach (char c in str)
        {
            if (!Char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
}