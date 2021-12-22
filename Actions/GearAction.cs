namespace TheFinalBattle_v1;

internal class GearAction : IAction
{
    private readonly IGear _gear;
    public GearAction(IGear gear)
    {
        _gear = gear;
    }
    public void Run(Battle battle, Character character)
    {
        if (character.Gear.GetType() == typeof(NoGear))
        {
            ConsoleHelper.WriteLine($"{character} equipped {_gear.Name}.", ConsoleColor.Gray);
            character.Gear = _gear;
        }
        else if (character.Gear.GetType() != typeof(NoGear))
        {
            ConsoleHelper.WriteLine($"{character} unequiped {character.Gear.Name} and equipped {_gear.Name}.", ConsoleColor.Gray);
            character.Gear = _gear;
        }
    }
}
