namespace TheFinalBattle_v1;

public abstract class GameObject
{
    public string Name { get; set; }
    public bool IsAlive
    {
        get 
        {
            if (HP > 0) return true;
            else return false;
        }
    }
    public int ID { get; set; }
    public double MaxHP { get; set; }
    public double HP { get; set; }
    public Guid PlayerID { get; }   
    public GameObject(string name, Guid playerID)
    {
        Name = name;
        PlayerID = playerID;
    }
}
public enum Team { Heroes, Monsters }
