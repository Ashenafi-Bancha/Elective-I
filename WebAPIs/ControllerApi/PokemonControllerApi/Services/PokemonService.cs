using MongoDB.Driver;
using Microsoft.Extensions.Options;

public class PokemonService
{
    private readonly IMongoCollection<Pokemon> _pokemonCollection;

    public PokemonService(IOptions<DBSettings> dbSettings)
    {
        var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

        _pokemonCollection = database.GetCollection<Pokemon>("Pokemon");
    }

    // Add Pokemon
    public void AddPokemon(Pokemon pokemon)
    {
        _pokemonCollection.InsertOne(pokemon);
    }

    // Get all Pokemon
    public List<Pokemon> GetAllPokemon()
    {
        return _pokemonCollection.Find(_ => true).ToList();
    }

    // Get Pokemon by name
    public Pokemon? GetPokemonByName(string name)
    {
        return _pokemonCollection.Find(p => p.Name == name).FirstOrDefault();
    }

    // Delete Pokemon by name
    public bool DeletePokemonByName(string name)
    {
        var result = _pokemonCollection.DeleteOne(p => p.Name == name);
        return result.DeletedCount > 0;
    }

    // Train Pokemon by name
    public bool TrainPokemonByName(string name)
    {
        var pokemon = _pokemonCollection.Find(p => p.Name == name).FirstOrDefault();
        if (pokemon == null) return false;

        pokemon.Train(); // Assuming Pokemon class has Train() method
        _pokemonCollection.ReplaceOne(p => p.Name == name, pokemon);
        return true;
    }
}

