namespace TheFinalBattle_v1;

public abstract class GameObject
{   
    public int ID { get; set; } 
    public Guid PlayerID { get; }   
    public GameObject(Guid playerID) { }
}
public enum Team { Heroes, Monsters }
