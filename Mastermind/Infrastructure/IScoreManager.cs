namespace Infrastructure
{
    public interface IScoreManager
    {
        HighscoreEntry[] List();
        void Add(HighscoreEntry entry);
    }
}