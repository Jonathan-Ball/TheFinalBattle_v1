namespace TheFinalBattle_v1;

public class NothingAction : IAction
{
    public void Run(Battle game, Character acter)
    {
        ConsoleHelper.WriteLine($"{acter.Name} did NOTHING.", ConsoleColor.Gray);
    }
}
