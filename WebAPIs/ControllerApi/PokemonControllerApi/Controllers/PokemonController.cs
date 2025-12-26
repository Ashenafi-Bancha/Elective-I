using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/pokemon")]
public class PokemonController : ControllerBase
{
    private readonly PokemonService _pokemonService;

    public PokemonController(PokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_pokemonService.GetAllPokemon());
    }

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var pokemon = _pokemonService.GetPokemonByName(name);
        if (pokemon == null) return NotFound();
        return Ok(pokemon);
    }

    [HttpPost]
    public IActionResult Add(Pokemon pokemon)
    {
        _pokemonService.AddPokemon(pokemon);
        return Ok("Pokemon added successfully");
    }

    // Change Delete to use name instead of id
    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        var success = _pokemonService.DeletePokemonByName(name);
        if (!success) return NotFound();
        return Ok("Pokemon deleted");
    }

    // Change Train to use name instead of id
    [HttpPut("train/{name}")]
    public IActionResult Train(string name)
    {
        var success = _pokemonService.TrainPokemonByName(name);
        if (!success) return NotFound();
        return Ok("Pokemon trained");
    }
}
