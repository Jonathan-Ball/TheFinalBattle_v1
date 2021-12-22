namespace TheFinalBattle_v1;

internal class NoGear : IGear
{
    public string Name { get; } = "NO GEAR";
    public IAttack Attack { get; } = new NoAttack();
}
