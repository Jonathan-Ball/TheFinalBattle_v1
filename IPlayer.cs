namespace TheFinalBattle_v1;

public interface IPlayer
{
    Guid Guid { get; init; }
    IAction GetAction(Battle game, Character character);
}
