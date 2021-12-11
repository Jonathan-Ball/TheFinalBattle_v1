namespace TheFinalBattle_v1;

public class PunchAttack : IAttack
{
    public string Name => "PUNCH";
    public double Damage => SetDamage();
    public double SetDamage() => 1;
}  
