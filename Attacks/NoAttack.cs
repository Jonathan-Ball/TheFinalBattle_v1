namespace TheFinalBattle_v1;

public class NoAttack : IAttack
{
    public string Name => "NO ATTACK";
    public AttackData Generate() => new AttackData(SetDamageData());
    public double SetDamageData() => 0;
}
