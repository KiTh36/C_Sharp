using System;

public static class ConfigParser
{
    public static (string key, string value) ParseSetting(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            throw new ArgumentNullException(nameof(line));

        var parts = line.Split('=', 2); // разделяем только на 2 части
        if (parts.Length != 2)
            throw new FormatException($"Expected format key=value, got: {line}");

        return (parts[0].Trim(), parts[1].Trim());
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            var result = ConfigParser.ParseSetting("username=admin");
            Console.WriteLine($"key={result.key}, value={result.value}");

            var invalid = ConfigParser.ParseSetting("invalid_line"); 
        }
        catch (FormatException ex) when (ex.Message.Contains("key=value"))
        {
            Console.WriteLine("Format error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Parsing finished.");
        }
    }
}
