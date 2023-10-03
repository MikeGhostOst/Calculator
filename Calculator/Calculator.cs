namespace CalculatorApp;

class Calculator
{
    public void Run()
    {
        Console.WriteLine("Welcome to the calculator app. Type your command.");

        History history = new History();

        while (true)
        {
            Console.Write("> ");

            string userInput = Console.ReadLine() ?? "";
            List<ParseToken> tokens = TokenParser.Parse(userInput);
            Command? command = _getCommand(tokens, history);
            
            if (command == null)
            {
                Console.WriteLine("The command is incorrect.");
            }
            else
            {
                command.Execute(history, out bool isExit);

                if (isExit)
                {
                    break;
                }
                else
                {
                    history.AddCommand(command);
                }
            }
        }
    }

    Command? _getCommand(List<ParseToken> tokens, History history)
    {
        Command? command;

        if (ExitCommand.ParseCommand(tokens, out command))
        {
            return command;
        }
        else if (DeclarationCommand.ParseCommand(tokens, history, out command))
        {
            return command;
        }
        else if (HistoryCommand.ParseCommand(tokens, out command))
        {
            return command;
        }
        if (ArithmeticCommand.ParseCommand(tokens, history, out command))
        {
            return command;
        }
        else
        {
            return null;
        }
    }
}


