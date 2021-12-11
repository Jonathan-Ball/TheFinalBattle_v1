namespace TheFinalBattle_v1;

public static class Renderer
{
    public static void Render(Battle battle, Character currentPlayer)
    {
        ConsoleHelper.WriteLine($"+================================================>- BATTLE #{battle.Number} -<================================================+", ConsoleColor.White);

        foreach (Character character in battle.Heroes.Characters)
        {
            ConsoleColor color = character == currentPlayer ? ConsoleColor.Magenta : ConsoleColor.Gray;
            ConsoleHelper.WriteLine($"{character.Name,-45} ({character.HP,3}/{character.MaxHP,-3})", color);

        }
        ConsoleHelper.WriteLine("------------------------------------------------------ VS -------------------------------------------------------", ConsoleColor.White);
        foreach (Character character in battle.Monsters.Characters)
        {
            ConsoleColor color = character == currentPlayer ? ConsoleColor.Magenta : ConsoleColor.Gray;
            ConsoleHelper.WriteLine($"                                                          {character.Name,45} ({character.HP,3}/{character.MaxHP,-3})", color);
        }
        ConsoleHelper.WriteLine("+===============================================================================================================+", ConsoleColor.White);
    }
}
