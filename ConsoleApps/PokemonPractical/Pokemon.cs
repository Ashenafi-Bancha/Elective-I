public class Pokemon
{
    public string Name { get; }
    public int Level { get; private set; }
    

    public event Action<string, int>? LeveledUp;

    public Pokemon(string name)
    {
        Name = name;
        Level = 1;
        
    }

    public void GainExperience(int amount)
    {
        Level += amount;
        
        LeveledUp?.Invoke(Name, amount);
    }
}
