namespace TheFinalBattle_v1;

public class Party
{
    public Inventory Inventory { get; set; } = new Inventory();
    public Team Team { get; init; }
    public IPlayer Player { get; init; }
    public List<Character> Characters { get; } = new List<Character>();
    public Party(IPlayer player, int healthPotions)
    {
        Player = player;
        for (int i = 0; i < healthPotions; i++)
            Inventory.Items.Add(new HealthPotionItem());
    }
}
