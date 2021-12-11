namespace TheFinalBattle_v1;

public class Inventory
{
    public List<IItem> Items { get; set; } = new List<IItem>();
    public IItem SelectItem(IPlayer player, bool needHeal)
    {
        int input = 0;
        if (Items.Count == 0)
        {
            if (player is HumanPlayer)
            {
                ConsoleHelper.WriteLine("You have no items in your inventory.", ConsoleColor.DarkMagenta);
                return new NoItem();
            }
            else if (player is ComputerPlayer)
            {
                ConsoleHelper.WriteLine($"The computer tried to use an item but there were none in the inventory.", ConsoleColor.DarkMagenta);
                return new NoItem();
            }           
        }
        if (player is HumanPlayer)
        {
            string prompt;
            List<string> itemName = new List<string>();
            foreach (var item in Items)
                itemName.Add(item.Name);
            for (int i = 0; i < Items.Count; i++)
                Console.WriteLine($"{i + 1}. {itemName[i]}");
            if (needHeal) prompt = "Please select an item (You may want to heal): ";
            else prompt = "Please select an item: ";
            int.TryParse(ConsoleHelper.Prompt(prompt), out input);
        }
        else if (player is ComputerPlayer)
        {
            if (needHeal) return SelectHealthPotion();         
        }
        return input switch
        {
            1 => Items[0],
            2 => Items[1],
            3 => Items[2],
            4 => Items[3],
            5 => Items[4],
            _ => Items[0]
        };
    }
    public IItem SelectHealthPotion()
    {
        var healthItem = Items.Where(i => i.Name == "HEALTH POTION").First();
        return healthItem;
    }
    public bool DetectHealthPotion()
    {
        foreach (IItem i in Items)
            if (i.GetType() == typeof(HealthPotionItem)) return true;
        return false;
    }
    public void UseItem(IItem item)
    {
        Items.Remove(item);
    }
}
