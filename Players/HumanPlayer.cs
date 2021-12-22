namespace TheFinalBattle_v1;

public class HumanPlayer : IPlayer
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public IAction GetAction(Battle battle, Character character)
    {
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. Equip Gear");
            Console.WriteLine("0. Do nothing");
            ConsoleHelper.Write("Select an action: ", ConsoleColor.Blue);
            Party enemyParty = battle.GetEnemyPartyFor(character);
            Party friendlyParty = battle.GetFriendlyPartyFor(character);
            while (true)
            {
                int.TryParse(ConsoleHelper.ReadLine(), out int input);
                if (input >= 0 && input <= 3)
                {
                    return input switch
                    {
                        0 => new NothingAction(),
                        1 => new AttackAction(character.GetAttack(this), enemyParty.Characters[0]),
                        2 => new ItemAction(friendlyParty.Inventory.SelectItem(this, character)),
                        3 => new GearAction(friendlyParty.Inventory.SelectGear(this, character)),
                        _ => new NothingAction()
                    };
                }
                ConsoleHelper.Write("Select a valid action: ", ConsoleColor.Red);
            }
        }
    }
}
