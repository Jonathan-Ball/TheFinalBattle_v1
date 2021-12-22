namespace TheFinalBattle_v1;

public class UncodedOne : Character
{
    public override IAttack StandardAttack { get; } = new UnravelAttack();
    public UncodedOne(string name, double maxHP, double hp, IGear gear, Guid playerID) : base(name, maxHP, hp, gear, playerID) { }
    public override string ToString() => Name;
}

