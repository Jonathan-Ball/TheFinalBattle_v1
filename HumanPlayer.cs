namespace TheFinalBattle_v1;

public class HumanPlayer : IPlayer
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public IAction GetAction(Battle battle, Character character)
    {
        {
            Console.WriteLine("1. Basic Attack");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("0. Do nothing");
            ConsoleHelper.Write("Select an action: ", ConsoleColor.Blue);
            Party enemyParty = battle.GetEnemyPartyFor(character);
            Party friendlyParty = battle.GetFriendlyPartyFor(character);
            bool needHeal = character.HP < character.MaxHP / 2;
            while (true)
            {
                int.TryParse(ConsoleHelper.ReadLine(), out int input);
                if (input >= 0 && input <= 2)
                {
                    return input switch
                    {
                        0 => new NothingAction(battle.GetEnemyPartyFor(character).Characters[0]),
                        1 => new AttackAction(character.StandardAttack, battle.GetEnemyPartyFor(character).Characters[0]),
                        2 => new ItemAction(friendlyParty.Inventory.SelectItem(this, needHeal)),
                        _ => new NothingAction(battle.GetEnemyPartyFor(character).Characters[0])
                    };
                }
                ConsoleHelper.Write("Select a valid action: ", ConsoleColor.Red);
            }
        }
    }
}
