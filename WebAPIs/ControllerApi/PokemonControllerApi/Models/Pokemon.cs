//1. Define the Pokemon class
public class Pokemon
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    
    public void GainExperience(int amount)
    {
        Level += amount;
        

    }
}
