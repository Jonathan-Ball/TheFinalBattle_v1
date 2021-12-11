namespace TheFinalBattle_v1;

public class NothingAction : IAction
{
    private readonly Character _target;
    public NothingAction(Character character)
    {
        _target = character;
    }
    public void Run(Battle game, Character acter)
    {
        ConsoleHelper.WriteLine($"{acter.Name} used NOTHING on {_target.Name}.", ConsoleColor.Gray);
    }
}
