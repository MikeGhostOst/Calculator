namespace CalculatorApp;

class History
{
    List<Command> _commands = new List<Command>();
    Dictionary<string, int> _vars = new Dictionary<string, int>();

    public List<Command> GetHistory()
    {
        return _commands;
    }

    public void AddCommand(Command command)
    {
        _commands.Add(command);
    }

    public bool HasVariable(string name)
    {
        return _vars.ContainsKey(name);
    }

    public int GetVariableValue(string name)
    {
        return _vars[name];
    }
    public void SetVariable(string name, int value)
    {
        _vars.Add(name, value);
    }
}
