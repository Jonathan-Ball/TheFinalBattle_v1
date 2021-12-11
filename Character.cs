namespace TheFinalBattle_v1;

public abstract class Character : GameObject
{ 
    public abstract IAttack StandardAttack { get; }
    public Character(string name, Guid guid) : base(name, guid) { }
    public virtual void LoseHP(double damage)
    {
        if (HP > 0) HP -= damage;
    }
    public virtual void GainHP(double heals)
    {
        double hp = HP;
        if (hp + heals > MaxHP) HP = MaxHP;
        else HP += heals;
    }
}
