namespace Infrastructure
{
    public interface IGame
    {
        bool Guess(string bet, out string result);
        int Result { get; }
    }
}