namespace TheFinalBattle_v1;

public static class ConsoleHelper
{
    public static void SlowPrint(string output, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        foreach (char character in output)
        {
            Console.Write(character);
            Thread.Sleep(150);
        }
        Thread.Sleep(250);
        Console.WriteLine();
        Console.ForegroundColor= ConsoleColor.White;
    }
    public static void WriteLine(string output, ConsoleColor color)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(output);
        Console.ForegroundColor = previousColor;
    }
    public static void Write(string output, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(output);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static string? ReadLine()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        string? input = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }
    public static string? Prompt(string prompt)
    {
        ConsoleHelper.Write(prompt, ConsoleColor.Magenta);
        Console.ForegroundColor = ConsoleColor.Cyan;
        string? input = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }
}
