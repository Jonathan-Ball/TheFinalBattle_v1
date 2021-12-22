namespace TheFinalBattle_v1;

public class TrueProgrammer : Character
{
    public override IAttack StandardAttack { get; } = new PunchAttack();
    public TrueProgrammer(string name, double maxHP, double hp, IGear gear, Guid playerID) : base(name, maxHP, hp, gear, playerID) { }
    public override string ToString() => Name;
}
