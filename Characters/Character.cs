namespace TheFinalBattle_v1;

public abstract class Character : GameObject
{
    public string Name { get; set; }
    public IGear Gear { get; set; }
    public abstract IAttack StandardAttack { get; }
    public IAttack SecondaryAttack
    {
        get
        {
            return _secondaryAttack;
        }
        set
        {
            _secondaryAttack = SetSecondaryAttack();
        }
    }
    private IAttack? _secondaryAttack;
    public double MaxHP { get; set; }
    public double HP { get; set; }
    public bool IsAlive
    {
        get
        {
            if (HP > 0) return true;
            else return false;
        }
    }
    public Character(string name, double maxHP, double hp, IGear gear, Guid guid) : base(guid) 
    {
        Name = name;
        MaxHP = maxHP;
        HP = hp;
        Gear = gear;
    }
    public void LoseHP(double damage)
    {
        if (HP > 0)
        {
            if (damage > HP) HP = 0;
            else HP -= damage;
        }
    }
    public void GainHP(double heals)
    {
        double hp = HP;
        if (hp + heals > MaxHP) HP = MaxHP;
        else HP += heals;
    }
    public IAttack GetAttack(IPlayer player)
    {
        Random rnd = new Random();
        if (!(Gear is NoGear))
        {
            if (player is HumanPlayer)
            {
                string prompt = "Select an attack: ";
                Console.WriteLine($"1. {StandardAttack.Name}");
                Console.WriteLine($"2. {Gear.Attack.Name}");
                int.TryParse(ConsoleHelper.Prompt(prompt), out int input);
                while (true)
                {
                    if (input > 0 && input < 3) break;
                    ConsoleHelper.Write("Please select a valid attack: ", ConsoleColor.DarkRed);
                    int.TryParse(ConsoleHelper.ReadLine(), out input);
                }
                return input switch
                {
                    1 => StandardAttack,
                    2 => Gear.Attack,
                    _ => StandardAttack
                };                                        
            }
            else if (player is ComputerPlayer)
            {
                int chance = 70;
                int randomNumber = rnd.Next(101);
                if (randomNumber < chance)
                {
                    return Gear.Attack;
                }
            }
        }
        return StandardAttack;
    }
    public IAttack SetSecondaryAttack()
    {
        if (Gear.GetType() != typeof(NoGear)) return Gear.Attack;
        else { return new NoAttack(); }
    }
}
