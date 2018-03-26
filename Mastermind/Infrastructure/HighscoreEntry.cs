namespace Infrastructure
{
    public class HighscoreEntry
    {
        public HighscoreEntry(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int Score { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Score} punktow";
        }
    }
}
