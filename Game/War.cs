namespace TheFinalBattle_v1;

public class War
{
    public bool HasLost { get; private set; } = false;
    private List<Battle> Battles { get; }
    public War(List<Battle> battles) { Battles = battles; }
    public void Run()
    {
        foreach (Battle battle in Battles)         
            if (!battle.Run()){ ConsoleHelper.WriteLine("YOU HAVE LOST THE WAR!", ConsoleColor.DarkRed); HasLost = true; break; }
        if (!HasLost) ConsoleHelper.WriteLine("YOU HAVE WON THE WAR!", ConsoleColor.DarkGreen);
    }  
}
