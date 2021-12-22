namespace TheFinalBattle_v1;

public class DaggerAttack : IAttack
{
    private static readonly Random _random = new();
    public string Name => "STAB";
    public AttackData Generate() => new AttackData(SetDamageData());
    public double SetDamageData()
    {
        int chance = 30;
        int randomNumber = _random.Next(101);
        if (randomNumber < chance)
            return 2;
        else return 1;
    }
}
