namespace TheFinalBattle_v1;

public class UnravelAttack : IAttack
{
    private static readonly Random _random = new();
    public string Name => "UNRAVEL";
    public AttackData Generate() => new AttackData(SetDamageData());
    public double SetDamageData() => _random.Next(3);
}
