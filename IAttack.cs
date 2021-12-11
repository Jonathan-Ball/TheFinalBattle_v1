namespace TheFinalBattle_v1;

public interface IAttack
{
    string Name { get; }
    double Damage { get; }
    double SetDamage();
}
