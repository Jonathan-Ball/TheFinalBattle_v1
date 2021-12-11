namespace TheFinalBattle_v1;

public class Inventory
{
    public List<IItem> Items { get; set; } = new List<IItem>();
    public IItem SelectItem(IPlayer player)
    {
        int input = 0;
        if (player is HumanPlayer)
        {
            List<string> itemName = new List<string>();
            foreach (var item in Items)
                itemName.Add(item.Name);
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {itemName[i]}");
            }
            if (Items.Count == 0)
            {
                ConsoleHelper.WriteLine("You have no items in your inventory.", ConsoleColor.DarkMagenta);
                return new NoItem();
            }
            else
            {
                int.TryParse(ConsoleHelper.Prompt("Please select an item: "), out input);
            }
        }
        else if (player is ComputerPlayer)
        {
            if (Items.Count == 0)
            {
                ConsoleHelper.WriteLine($"The computer tried to use an item but there were none in the inventory.", ConsoleColor.DarkMagenta);
                return new NoItem();
            }
            else
            {
                Random random = new Random();
                input = 1;
            }          
        }
        
        return input switch
        {
            1 => Items[0],
            2 => Items[1],
            3 => Items[2],
            4 => Items[3],
            5 => Items[4],
            _ => new NoItem()
        };
    }
    public void UseItem(IItem item)
    {
        Items.Remove(item);
    }
}
