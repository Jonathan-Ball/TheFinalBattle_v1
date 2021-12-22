namespace TheFinalBattle_v1;

public class Skeleton : Character
{
    public override IAttack StandardAttack => new BoneCrunchAttack();
    public Skeleton(string name, double maxHP, double hp, IGear gear, Guid playerID) : base(name, maxHP, hp, gear, playerID) { } 
    public override string ToString() => Name;
}
