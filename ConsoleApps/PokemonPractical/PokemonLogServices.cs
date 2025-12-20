public class PokemonLogService
{
    private readonly List<PokemonLogEntry> _logs = new();

    public void Save(string name, int gainedAmount)
    {
        var entry = new PokemonLogEntry(name, gainedAmount, DateTime.Now);
        _logs.Add(entry);
    }

    public List<PokemonLogEntry> GetAll()
    {
        return _logs;
    }
}
