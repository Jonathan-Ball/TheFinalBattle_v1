namespace TheFinalBattle_v1;

public class ItemAction : IAction
{
    private readonly IItem _item;
    public ItemAction(IItem item)
    {
        _item = item;
    }
    public void Run(Battle battle, Character character)
    {
        if (_item is NoItem) ConsoleHelper.WriteLine($"{character} searched for an item to use on THEMSELVES but found nothing.", ConsoleColor.Gray);
        if (_item is HealthPotionItem)
        {
            character.GainHP(_item.Action); 
            battle.GetCurrentInventoryFor(battle.GetFriendlyPartyFor(character)).UseItem(_item);
            ConsoleHelper.WriteLine($"{character} is now at {character.HP}/{character.MaxHP} HP.", ConsoleColor.DarkGreen);
        }
    }
}
