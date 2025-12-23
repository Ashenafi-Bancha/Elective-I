using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TrainerController : ControllerBase
{
    // In-memory trainer list
    private static List<Trainer> trainers = new List<Trainer>();

    // POST /api/trainers
    [HttpPost]
    public ActionResult<Trainer> CreateTrainer([FromBody] Trainer trainer)
    {
        // Simple Id generation
        trainer.Id = trainers.Count > 0 ? trainers.Max(t => t.Id) + 1 : 1;
        trainers.Add(trainer);
        return CreatedAtAction(nameof(GetTrainerById), new { id = trainer.Id }, trainer);
    }

    // GET /api/trainers
    [HttpGet]
    public ActionResult<List<Trainer>> GetAllTrainers()
    {
        return Ok(trainers);
    }

    // GET /api/trainers/{id}
    [HttpGet("{id}")]
    public ActionResult<Trainer> GetTrainerById(int id)
    {
        var trainer = trainers.FirstOrDefault(t => t.Id == id);
        if (trainer == null) return NotFound($"Trainer with Id {id} not found.");
        return Ok(trainer);
    }

    // POST /api/trainers/{id}/pokemon/{pokemonName}
    [HttpPut("{id}/pokemon/{pokemonName}")]
    public ActionResult<Trainer> AddPokemonToTrainer(int id, string pokemonName)
    {
        var trainer = trainers.FirstOrDefault(t => t.Id == id);
        if (trainer == null) return NotFound($"Trainer with Id {id} not found.");

        // Add Pokemon if it doesn't already exist
        if (!trainer.PokemonNames.Contains(pokemonName, StringComparer.OrdinalIgnoreCase))
        {
            trainer.PokemonNames.Add(pokemonName);
        }

        return Ok(trainer);
    }
}

