using NeutralPractice;

var cases = new (string Name, string?[] Input, string Expected)[]
{
    ("empty array", [], "(empty)"),
    ("single value", ["alpha"], "1: alpha\r\n"),
    ("null element", [null], "1: \r\n"),
    ("empty string", [""], "1: \r\n"),
    ("whitespace", ["  alpha  "], "1:   alpha  \r\n"),
    ("embedded newline", ["a\nb"], "1: a\nb\r\n"),
    ("ordered rows", ["beta", "alpha"], "1: beta\r\n2: alpha\r\n")
};

foreach (var test in cases)
{
    var actual = LegacyFormatter.Format(test.Input);
    if (!string.Equals(actual, test.Expected, StringComparison.Ordinal))
    {
        throw new InvalidOperationException(
            $"{test.Name}: expected [{Escape(test.Expected)}], actual [{Escape(actual)}].");
    }
}

try
{
    LegacyFormatter.Format(null!);
    throw new InvalidOperationException("null array: expected ArgumentNullException.");
}
catch (ArgumentNullException exception) when (exception.ParamName == "values")
{
}

Console.WriteLine($"PASS: {cases.Length + 1} characterization checks.");

static string Escape(string value) => value.Replace("\r", "\\r").Replace("\n", "\\n");
