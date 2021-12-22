namespace TheFinalBattle_v1;

public class DaggerGear : IGear
{
    public string Name => "DAGGER";
    public IAttack Attack { get; } = new DaggerAttack();
}
