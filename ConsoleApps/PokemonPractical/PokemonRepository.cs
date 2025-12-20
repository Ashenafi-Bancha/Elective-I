
public class PokemonRepository
{
    // Private list to store Pokemon objects
    private List<Pokemon> pokemons = new List<Pokemon>();

    // Add a Pokemon to the repository
    public void Add(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
    }

    // Get a Pokemon by name
    public Pokemon GetByName(string name)
    {
        return pokemons.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    // Get all Pokemons
    public List<Pokemon> GetAll()
    {
        return pokemons;
    }
}
