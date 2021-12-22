namespace TheFinalBattle_v1;

public class PunchAttack : IAttack
{
    public string Name => "PUNCH";
    public AttackData Generate() => new AttackData(SetDamageData());
    public double SetDamageData() => 1;
}  
