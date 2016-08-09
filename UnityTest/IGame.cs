namespace UnityTest
{
    public interface IGame
    {
        string Name { get; }
        int CurrentPlayers { get; }
        int MinPlayers { get; }
        int MaxPlayers { get; }

        void addPlayer();
        void removePlayer();
        void play();
        string result();
    }
}
