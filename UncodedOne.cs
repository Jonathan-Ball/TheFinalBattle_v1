namespace TheFinalBattle_v1;

public class UncodedOne : Character
{
    public override IAttack StandardAttack { get; } = new UnravelAttack();
    public UncodedOne(string name, Guid playerID) : base(name, playerID) { }
    public override string ToString() => Name;
}

