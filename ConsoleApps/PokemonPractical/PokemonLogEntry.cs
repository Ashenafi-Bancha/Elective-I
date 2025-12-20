public class PokemonLogEntry
{
    public string Name { get; }
    public int GainedLevels { get; }
    public DateTime Timestamp { get; }

    public PokemonLogEntry(string name, int gainedLevels, DateTime timestamp)
    {
        Name = name;
        GainedLevels = gainedLevels;
        Timestamp = timestamp;
    }
}
