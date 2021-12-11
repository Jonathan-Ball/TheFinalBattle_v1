namespace TheFinalBattle_v1;

public class Battle
{
    public int Number { get; init; }
    private int Round { get; set; } = 1;
    public Party Heroes { get; private set; }
    public Party Monsters { get; private set; } 
    public Guid ID { get; set; }
    public Battle(int number, Party heroes, Party monsters, Guid guid)
    {
        Number = number;
        Heroes = heroes;
        Monsters = monsters;
        ID = guid;
    }
    public bool Run()
    {
        ConsoleHelper.WriteLine($"-===- BATTLE #{Number} -===-", ConsoleColor.Blue);
        while (true)
        {
            Console.WriteLine($"Round: {Round}");
            List<Party> parties = new List<Party>() { Heroes, Monsters };           
            foreach (Party party in parties)
            {                                          
                foreach (Character character in party.Characters)
                {
                    Renderer.Render(this, character);
                    ConsoleHelper.WriteLine($"It is {character}'s Turn", ConsoleColor.Yellow);
                    party.Player.GetAction(this, character).Run(this, character);
                    RemoveDeadCharacters(parties);
                    if (HeroesHaveWon(this)) { ConsoleHelper.WriteLine("YOU HAVE WON THIS BATTLE!", ConsoleColor.Green); return true; }
                    else if (MonstersHaveWon(this)) { ConsoleHelper.WriteLine("YOU HAVE LOST THIS BATTLE!", ConsoleColor.Red); return false; }
                }
            }
            Round++;
        }
    }
    public Party GetEnemyPartyFor(Character character) => Heroes.Characters.Contains(character) ? Monsters : Heroes;
    public Party GetFriendlyPartyFor(Character character) => Heroes.Characters.Contains(character) ? Heroes : Monsters;
    public Inventory GetCurrentInventoryFor(Party party) => party.Inventory; 
    public bool HeroesHaveWon(Battle battle) => battle.Monsters.Characters.Count == 0 ? true : false;
    public bool MonstersHaveWon(Battle battle) => battle.Heroes.Characters.Count == 0 ? true : false;
    public void RemoveDeadCharacters(List<Party> parties)
    {
        foreach (Party party in parties)
        {
            foreach (Character character in party.Characters)
            {
                if (!character.IsAlive)
                {
                    party.Characters.Remove(character);
                    ConsoleHelper.WriteLine($"{character} has been slain!", ConsoleColor.DarkGray);
                    break;
                }
            }
        }                         
    }    
}
