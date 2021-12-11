namespace TheFinalBattle_v1;

public interface IItem
{
    string Name { get; }
    double Action { get; }
    double SetAction();
}
