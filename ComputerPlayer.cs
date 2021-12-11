namespace TheFinalBattle_v1;

public class ComputerPlayer : IPlayer
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public IAction GetAction(Battle battle, Character character)
    {
        int input;
        Party enemyParty = battle.GetEnemyPartyFor(character);
        Party friendlyParty = battle.GetFriendlyPartyFor(character);
        bool needHeal = character.HP < character.MaxHP / 2;
        Random rnd = new();
        if (needHeal && friendlyParty.Inventory.DetectHealthPotion()) input = 2;
        else input = rnd.Next(1, 2);       
        Thread.Sleep(1500);
        return input switch
        {
            1 => new AttackAction(character.StandardAttack, enemyParty.Characters[rnd.Next(0, enemyParty.Characters.Count)]),
            2 => new ItemAction(friendlyParty.Inventory.SelectItem(this, needHeal)),
            _ => new AttackAction(character.StandardAttack, enemyParty.Characters[rnd.Next(0, enemyParty.Characters.Count)]),
        };
    }
}
