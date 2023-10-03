namespace CalculatorApp;

abstract class Command
{
    public abstract void Execute(History history, out bool isExit);

    public Command(List<ParseToken> tokens)
    {
        _tokens = tokens;
    }

    public override string ToString()
    {
        string str = "";

        foreach (ParseToken token in _tokens) {
            str += token.Value;
        }

        return str;
    }

    protected List<ParseToken> _tokens;
}
