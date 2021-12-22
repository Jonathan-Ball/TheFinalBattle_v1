namespace TheFinalBattle_v1;

public class SwordAttack : IAttack
{
    private static readonly Random _random = new();
    public string Name => "SLASH";
    public AttackData Generate() => new AttackData(SetDamageData());
    public double SetDamageData()
    {
        int chance = 25;
        int randomNumber = _random.Next(101);
        if (randomNumber < chance)
            return 3;
        else return 2;
    }
}
