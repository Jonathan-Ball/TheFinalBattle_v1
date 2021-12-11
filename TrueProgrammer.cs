namespace TheFinalBattle_v1;

public class TrueProgrammer : Character
{

    public override IAttack StandardAttack { get; } = new PunchAttack();
    public TrueProgrammer(string name, Guid playerID) : base(name, playerID) { }
    public override string ToString() => Name;
}
