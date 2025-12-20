
  // Test 1
var p = new Pokemon("Pikachu");
p.GainExperience(3);
Console.WriteLine($"{p.Name} is now level {p.Level}");

// Test 2
var pikachu = new Pokemon("Pikachu");
var notifier = new NotificationService();
pikachu.LeveledUp += notifier.Announce;
pikachu.GainExperience(5);

// Test 3
var repository = new PokemonRepository();
var service = new PokemonService(repository);
service.RegisterPokemon("Charmander");
service.RegisterPokemon("Squirtle");
service.Train("Charmander", 2);
service.Train("Squirtle", 3);
var pokemons= service.GetPokemons();
foreach (var poke in pokemons)
{
 Console.WriteLine($"{poke.Name} - Level {poke.Level}");
}

// Test 4
var logService = new PokemonLogService();
var bulbasaur = new Pokemon("Bulbasaur");

bulbasaur.LeveledUp += logService.Save;

bulbasaur.GainExperience(4);
bulbasaur.GainExperience(2);

foreach (var log in logService.GetAll())
{
    Console.WriteLine($"{log.Name} gained {log.GainedLevels} at {log.Timestamp}");
}

// Test 5

