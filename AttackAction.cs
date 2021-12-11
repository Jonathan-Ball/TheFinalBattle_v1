namespace TheFinalBattle_v1;

public class AttackAction : IAction
{
    private readonly IAttack _attack;
    private readonly Character _target;
    public AttackAction(IAttack attack, Character target)
    {
        _attack = attack;
        _target = target;
    }
    public void Run(Battle battle, Character attacker)
    {
        double dmg = _attack.Damage;
        string atkrName = attacker.Name;
        string atkName = _attack.Name;
        string trgtName = _target.Name;
        ConsoleHelper.WriteLine($"{atkrName} used {atkName} on {trgtName}.", ConsoleColor.Gray);
        _target.LoseHP(dmg);
        if (dmg > 0) ConsoleHelper.WriteLine($"The attack dealt {dmg} damage. {trgtName} is now at {_target.HP}/{_target.MaxHP} HP.", ConsoleColor.DarkRed);
        else ConsoleHelper.WriteLine($"The attack dealt no damage. {trgtName} is still at {_target.HP}/{_target.MaxHP} HP.", ConsoleColor.DarkYellow);
    }
}

