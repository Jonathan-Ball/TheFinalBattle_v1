namespace TheFinalBattle_v1;

public class UnravelAttack : IAttack
{
    public string Name => "UNRAVEL";
    public double Damage => SetDamage();
    public double SetDamage()
    {
        Random random = new Random();
        return random.Next(3);
    }
}
