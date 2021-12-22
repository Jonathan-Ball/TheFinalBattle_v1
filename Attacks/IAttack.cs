namespace TheFinalBattle_v1;

public interface IAttack
{
    string Name { get; }
    AttackData Generate();
    double SetDamageData();
}
