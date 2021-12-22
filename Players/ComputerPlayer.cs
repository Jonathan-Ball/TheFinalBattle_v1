namespace TheFinalBattle_v1;

public class ComputerPlayer : IPlayer
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public IAction GetAction(Battle battle, Character character)
    {
        int input;
        bool needItem;
        bool needGear;
        Random rnd = new Random();
        Party enemyParty = battle.GetEnemyPartyFor(character);
        Party friendlyParty = battle.GetFriendlyPartyFor(character);
        needItem = ItemCheck(character, friendlyParty);
        needGear = GearCheck(character, friendlyParty);
        if (needItem) input = 2;
        else if (needGear)
        {
            int chance = 50;
            int randomNumber = rnd.Next(101);
            if (randomNumber < chance)
                input = 3;
            else input = 1;
        }
        else input = 1;       
        Thread.Sleep(2000);
        return input switch
        {
            1 => new AttackAction(character.GetAttack(this), enemyParty.Characters[rnd.Next(0, enemyParty.Characters.Count)]),
            2 => new ItemAction(friendlyParty.Inventory.SelectItem(this, character)),
            3 => new GearAction(friendlyParty.Inventory.SelectGear(this, character)),
            _ => new AttackAction(character.GetAttack(this), enemyParty.Characters[rnd.Next(0, enemyParty.Characters.Count)]),
        };
    }
    public bool GearCheck(Character character, Party party)
    {
        if (character.Gear.GetType() == typeof(NoGear) && party.Inventory.Gears.Count > 0) return true;
        if (character.Gear.GetType() != typeof(SwordGear) && party.Inventory.DetectGear<SwordGear>()) return true;
        return false;
    }
    public bool ItemCheck(Character character, Party party)
    {
        if (character.HP < character.MaxHP / 2 && party.Inventory.DetectItem<HealthPotionItem>()) return true;
        return false;
    }
}
