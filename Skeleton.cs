namespace TheFinalBattle_v1;

public class Skeleton : Character
{
    public override IAttack StandardAttack => new BoneCrunchAttack();
    public Skeleton(string name, Guid playerID) : base(name, playerID) { } 
    public override string ToString() => Name;
}
