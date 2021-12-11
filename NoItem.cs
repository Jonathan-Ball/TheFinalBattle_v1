namespace TheFinalBattle_v1;

public class NoItem : IItem
{
    public string Name => "NO ITEM";
    public double Action => SetActionAmount();
    public double SetActionAmount() => 0;
}
