public class PokemonService
{
    private readonly PokemonRepository _repository;

    // FIX: Proper constructor that assigns the repository
    public PokemonService(PokemonRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public Pokemon RegisterPokemon(string name)
    {
        var pokemon = new Pokemon(name);
        _repository.Add(pokemon);
        return pokemon;
    }

    public void Train(string name, int amount)
    {
        var pokemon = _repository.GetByName(name);

        if (pokemon == null)
        {
            Console.WriteLine($"Pokemon '{name}' not found.");
            return;
        }

        pokemon.GainExperience(amount);
    }

    public List<Pokemon> GetPokemons()
    {
        return _repository.GetAll();
    }
}
