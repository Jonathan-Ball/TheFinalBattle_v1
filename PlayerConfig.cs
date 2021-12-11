namespace TheFinalBattle_v1
{
    public class PlayerConfig
    {
        public IPlayer Player1 { get; }
        public IPlayer Player2 { get; }
        public PlayerConfig(IPlayer player1, IPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}
