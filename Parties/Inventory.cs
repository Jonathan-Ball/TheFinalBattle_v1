namespace TheFinalBattle_v1;

public class Inventory
{
    public List<IItem> Items { get; set; } = new List<IItem>();
    public List<IGear> Gears { get; set; } = new List<IGear>();
    public IItem SelectItem(IPlayer player, Character character)
    {
        int input = 0;
        bool needHeal = character.HP < character.MaxHP / 2;
        if (Items.Count == 0)
        {
            ConsoleHelper.WriteLine("You have no items in your inventory.", ConsoleColor.DarkMagenta);
            return new NoItem();
        }
        if (player is ComputerPlayer)
        {
            var healthItem = Items.Where(i => i.Name == "HEALTH POTION").First(); ;
            if (needHeal) return healthItem;
        }
        else if (player is HumanPlayer)
        {
            int n = 1;
            string prompt;
            List<string> itemName = new List<string>();
            foreach (var item in Items)
            {
                Console.WriteLine($"{n}. {item.Name}"); n++;
            }
                
            if (needHeal) prompt = "Please select an item (You may want to heal): ";
            else prompt = "Please select an item: ";
            int.TryParse(ConsoleHelper.Prompt(prompt), out input);
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
    public IGear SelectGear(IPlayer player, Character character)
    {
        IGear gear;
        int input = 0;
        if (Gears.Count == 0)
        {
            ConsoleHelper.WriteLine("You have no gear in your inventory.", ConsoleColor.DarkMagenta);
            return new NoGear();
        }
        if (player is ComputerPlayer)
        {
            if (DetectGear<SwordGear>())
            {
                gear = Gears.Where(g => g.Name == "SWORD").First();
                Gears.Remove(gear);
                Gears.Add(character.Gear);
                return gear;
            }
            if (DetectGear<DaggerGear>())
            {
                gear = Gears.Where(g => g.Name == "DAGGER").First();
                Gears.Remove(gear);
                Gears.Add(character.Gear);
                return gear;
            }
        }
        else if (player is HumanPlayer)
        {
            int n = 1;
            string prompt;
            List<string> gearName = new List<string>();
            foreach (var gr in Gears)
            {
                Console.WriteLine($"{n}. {gr.Name}"); n++;
            }             
            prompt = "Please select gear to equip: ";
            int.TryParse(ConsoleHelper.Prompt(prompt), out input);
            while (true)
            {
                if (input > 0 && input <= Gears.Count) break;
                ConsoleHelper.Write("Please select a valid option: ", ConsoleColor.DarkRed);
                int.TryParse(ConsoleHelper.ReadLine(), out input);
            }
        }
        gear = input switch
        {
            1 => Gears[0],
            2 => Gears[1],
            3 => Gears[2],
            4 => Gears[3],
            5 => Gears[4],
            _ => Gears[0]
        };
        Gears.Remove(gear);
        Gears.Add(character.Gear);
        return gear;
    }
    public bool DetectItem<T>() where T : IItem
    {
        foreach (IItem i in Items)
            if (i.GetType() == typeof(T)) return true;
        return false;
    }
    public bool DetectGear<T>() where T : IGear
    {
        foreach (IGear g in Gears)
            if (g.GetType() == typeof(T)) return true;
        return false;
    }
    public void UseItem(IItem item) => Items.Remove(item);
}
