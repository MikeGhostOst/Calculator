namespace CalculatorApp;

struct ParseToken
{
	public TokenType Type;
	public string Value;
}

enum TokenType
{
	Name,
	Number,
	Operator,
	None
}
