namespace NeutralPractice;

public static class LegacyFormatter
{
    public static string Format(string?[] values)
    {
        ArgumentNullException.ThrowIfNull(values);

        if (values.Length == 0)
        {
            return "(empty)";
        }

        var result = "";
        for (var index = 0; index < values.Length; index++)
        {
            result = result + (index + 1) + ": " + values[index] + "\r\n";
        }

        return result;
    }
}
