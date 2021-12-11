namespace TheFinalBattle_v1;

public class BoneCrunchAttack : IAttack
{
    public string Name => "BONE CRUNCH";
    public double Damage => SetDamage();
    public double SetDamage()
    {
        Random random = new Random();
        return random.Next(2);
    }
}
