namespace TheFinalBattle_v1;

public class Program
{
    public static void Main()
    {
        Game.DisplayIntro();
        Game game = new(Game.GenerateWar());
        game.Run();
    }
}