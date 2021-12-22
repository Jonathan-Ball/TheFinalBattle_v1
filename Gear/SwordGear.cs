namespace TheFinalBattle_v1;

public class SwordGear : IGear
{
    public string Name { get; } = "SWORD";
    public IAttack Attack { get; } = new SwordAttack();
}
