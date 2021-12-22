namespace TheFinalBattle_v1;

public class Game
{
    public War War { get; }
    public Game(War war)
    {
        War = war;
    }
    /// <summary>
    /// Runs the game.
    /// </summary>
    public void Run()
    {
        DateTime dateTime = DateTime.Now;
        War.Run();
        TimeSpan endTime = DateTime.Now - dateTime;
        ConsoleHelper.WriteLine($"THIS GAME RAN FOR {endTime.Minutes}m {endTime.Seconds}s", ConsoleColor.DarkBlue);
    }
    /// <summary>
    /// The generates the hero party for the game.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="healthPotion"></param>
    /// <param name="daggerCount"></param>
    /// <param name="swordCount"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Party GenerateHeroParty(PlayerConfig player, int healthPotion, int daggerCount, int swordCount, string name)
    {
        Party heroes = new(player.Player1, healthPotion, daggerCount, swordCount) { Team = Team.Heroes };
        heroes.Characters.Add(new TrueProgrammer(name, 25, 25, new DaggerGear(), heroes.Player.Guid) { ID = 1 });
        heroes.Characters.Add(new Skeleton($"SKELZOR", 10, 10, new NoGear(), heroes.Player.Guid) { ID = 2 });
        return heroes;
    }
    /// <summary>
    /// This generates the battle with the specified configuration.
    /// </summary>
    /// <param name="heroes"></param>
    /// <param name="player"></param>
    /// <param name="daggerCount"></param>
    /// <param name="swordCount"></param>
    /// <param name="healthPotion"></param>
    /// <param name="battleNumber"></param>
    /// <param name="skeletonCount"></param>
    /// <param name="gearEquiped"></param>
    /// <param name="uncodedOnePresent"></param>
    /// <returns></returns>
    public static Battle GenerateBattle(Party heroes, PlayerConfig player, int skeletonCount, int daggerCount, int swordCount, int healthPotion, int battleNumber,  bool gearEquiped, bool uncodedOnePresent)
    {
        // Battle GUID
        Guid guid = Guid.NewGuid();
        // New Monsters
        Party monsters = new(player.Player2, healthPotion, daggerCount, swordCount) { Team = Team.Monsters };
        if (gearEquiped)
            for (int i = 0; i < skeletonCount; i++)
                monsters.Characters.Add(new Skeleton($"SKELETON {i + 1}", 5, 5, new DaggerGear(), monsters.Player.Guid) { ID = i });
        else
            for (int i = 0; i < skeletonCount; i++)
                monsters.Characters.Add(new Skeleton($"SKELETON {i + 1}", 5, 5, new NoGear(), monsters.Player.Guid) { ID = i });
        if (uncodedOnePresent)
        {
            if (gearEquiped) monsters.Characters.Add(new UncodedOne("UNCODED ONE", 15, 15, new SwordGear(), guid) { ID = skeletonCount + 1});
            else monsters.Characters.Add(new UncodedOne("UNCODED ONE", 15, 15, new NoGear(), guid) { ID = skeletonCount + 1 });
        }            
        // New Game
        return new Battle(battleNumber, heroes, monsters, guid);
    }
    /// <summary>
    /// This generates the war with each configured battle.
    /// </summary>
    /// <returns></returns>
    public static War GenerateWar()
    {
        string heroName = GetHeroName();
        PlayerConfig playerConfig = GetPlayerConfig();
        Party heroes = GenerateHeroParty(playerConfig, 3, 0, 1, heroName);
        Battle battle1 = GenerateBattle(heroes, playerConfig, 2, 0, 0, 0, 1, true, false);
        Battle battle2 = GenerateBattle(heroes, playerConfig, 2, 1, 1, 1, 2, false, false);
        Battle battle3 = GenerateBattle(heroes, playerConfig, 2, 1, 1, 2, 3, true, true);
        List<Battle> battles = new() { battle1, battle2, battle3 };
        War war = new(battles);
        return war;
    }
    /// <summary>
    /// Gets the heroes name.
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Gets the config of which player will control which party.
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Displays the intro to the game.
    /// </summary>
    public static void DisplayIntro()
    {
        ConsoleHelper.Write("Welcome to", ConsoleColor.Yellow);
        ConsoleHelper.SlowPrint("...", ConsoleColor.Yellow);
        ConsoleHelper.SlowPrint("The Final Battle!", ConsoleColor.DarkRed);
        Console.WriteLine();
    }
}
