using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    // In-memory Pokemon list
    private static List<Pokemon> pokemons = new()
    {
        new Pokemon { Id = 1, Name = "Pikachu", Level = 10 },
        new Pokemon { Id = 2, Name = "Charmander", Level = 8 },
        new Pokemon { Id = 3, Name = "Bulbasaur", Level = 12 }
    };

    // Home
   
    [HttpGet("/")]
    public IActionResult Home()
    {
        return Ok("Welcome to the Pokemon API!");
    }
    
    // GET /pokemon
   
    [HttpGet("/pokemon")]
    public IActionResult GetAll()
    {
        return Ok(pokemons);
    }

    // GET /pokemon/{id}
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var pokemon = pokemons.FirstOrDefault(p => p.Id == id);

        if (pokemon == null)
            return NotFound($"Pokemon with ID {id} not found.");

        return Ok(pokemon);
    }

    /
    // POST /pokemon
    // =========================
    [HttpPost]
    public IActionResult Create([FromBody] Pokemon pokemon)
    {
        if (pokemon == null)
            return BadRequest("Invalid Pokemon data.");

        pokemon.Id = pokemons.Count == 0
            ? 1
            : pokemons.Max(p => p.Id) + 1;

        pokemons.Add(pokemon);

        return CreatedAtAction(nameof(GetById), new { id = pokemon.Id }, pokemon);
    }

    // =========================
    // DELETE /pokemon/{id}
    // =========================
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var pokemon = pokemons.FirstOrDefault(p => p.Id == id);

        if (pokemon == null)
            return NotFound($"Pokemon with ID {id} does not exist.");

        pokemons.Remove(pokemon);

        return Ok(pokemons);
    }

    // =========================
    // PUT /pokemon/{name}/train/{amount}
    // =========================
    [HttpPut("{name}/train/{amount:int}")]
    public IActionResult Train(string name, int amount)
    {
        var pokemon = pokemons.FirstOrDefault(p =>
            p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (pokemon == null)
            return NotFound($"Pokemon '{name}' not found.");

        pokemon.GainExperience(amount);

        return Ok(pokemon);
    }
}

