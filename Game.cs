namespace TheFinalBattle_v1;

public class Game
{
    public War War { get; }
    public Game(War war)
    {
        War = war;
    }
    public void Run()
    {
        DateTime dateTime = DateTime.Now;
        War.Run();
        TimeSpan endTime = ComputeGameTime(dateTime);
        ConsoleHelper.WriteLine($"THIS GAME RAN FOR {endTime.Minutes}m {endTime.Seconds}s", ConsoleColor.DarkBlue);
    }
    private TimeSpan ComputeGameTime(DateTime dateTime)
    {
        TimeSpan timeSpan = DateTime.Now - dateTime;
        return timeSpan;
    }
    public static Party GenerateHeroParty(PlayerConfig player, int healthPotion, string name)
    {
        Party heroes = new(player.Player1, healthPotion) { Team = Team.Heroes };
        heroes.Characters.Add(new TrueProgrammer(name, heroes.Player.Guid) { MaxHP = 25, HP = 25, ID = 1 });
        return heroes;
    }
    public static Battle GenerateBattle(ref Party heroes, PlayerConfig player, int healthPotion, int battleNumber, int skeletonCount, bool uncodedOnePresent)
    {
        // Battle GUID
        Guid guid = Guid.NewGuid();
        // New Monsters
        Party monsters = new(player.Player2, healthPotion) { Team = Team.Monsters };
        for (int i = 0; i < skeletonCount; i++)
            monsters.Characters.Add(new Skeleton($"SKELETON {i+1}", monsters.Player.Guid) { MaxHP = 5, HP = 5, ID = i });
        if (uncodedOnePresent) monsters.Characters.Add(new UncodedOne("UNCODED ONE", guid) { MaxHP = 15, HP = 15, ID = skeletonCount + 1 });
        // New Game
        return new Battle(battleNumber, heroes, monsters, guid);
    }
    public static War GenerateWar()
    {
        string heroName = GetHeroName();
        PlayerConfig playerConfig = GetPlayerConfig();
        Party heroes = GenerateHeroParty(playerConfig, 3, heroName);
        Battle battle1 = GenerateBattle(ref heroes, playerConfig, 1, 1, 1, false);
        Battle battle2 = GenerateBattle(ref heroes, playerConfig, 1, 2, 2, false);
        Battle battle3 = GenerateBattle(ref heroes, playerConfig, 1, 3, 0, true);
        List<Battle> battles = new() { battle1, battle2, battle3 };
        War war = new(battles);
        return war;
    }
    public static string GetHeroName()
    {
        string? name;
        while (true)
        {
            name = ConsoleHelper.Prompt("What ist thine name hero: ");
            if (name != null && name != "") break;
            ConsoleHelper.Write("Listen here sire, I need a name: ", ConsoleColor.Red);
        }
        return name.ToUpper();
    }
    public static PlayerConfig GetPlayerConfig()
    {
        Console.WriteLine("1. PvC");
        Console.WriteLine("2. CvC");
        Console.WriteLine("3. PvP");
        ConsoleHelper.Write("Select a player config: ", ConsoleColor.Magenta);
        while (true)
        {
            int.TryParse(Console.ReadLine(), out int input);
            if (input > 0 && input <= 3)
            {
                return input switch
                {
                    1 => new PlayerConfig(new HumanPlayer(), new ComputerPlayer()),
                    2 => new PlayerConfig(new ComputerPlayer(), new ComputerPlayer()),
                    3 => new PlayerConfig(new HumanPlayer(), new HumanPlayer()),
                    _ => new PlayerConfig(new ComputerPlayer(), new ComputerPlayer())
                };              
            }
            ConsoleHelper.Write("Select a valid player config: ", ConsoleColor.Red);
        }
    }
    public static void DisplayIntro()
    {
        ConsoleHelper.Write("Welcome to", ConsoleColor.Yellow);
        ConsoleHelper.SlowPrint("...", ConsoleColor.Yellow);
        ConsoleHelper.SlowPrint("The Final Battle!", ConsoleColor.DarkRed);
        Console.WriteLine();
    }
}
