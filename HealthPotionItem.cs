namespace TheFinalBattle_v1;

public class HealthPotionItem : IItem
{
    public string Name => "HEALTH POTION";
    public double Action => SetActionAmount();
    public double SetActionAmount() => 10;
}