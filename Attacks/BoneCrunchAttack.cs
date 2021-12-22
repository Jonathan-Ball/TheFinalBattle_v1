namespace TheFinalBattle_v1;

public class BoneCrunchAttack : IAttack
{
    private static readonly Random _random = new();
    public string Name => "BONE CRUNCH";
    public AttackData Generate() => new AttackData(SetDamageData());
    public double SetDamageData() => _random.Next(2);
}
