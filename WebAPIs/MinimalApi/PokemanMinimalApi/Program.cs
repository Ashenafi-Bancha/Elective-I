var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Welecome to the PokemonMinimalAPI");

List<Pokemon> pokemons = new()
{
    new Pokemon { Id = 1, Name = "Pikachu", Level = 10 },
    new Pokemon { Id = 2, Name = "Charmander", Level = 8 },
    new Pokemon { Id = 3, Name = "Bulbasaur", Level = 12 }
};

// 3. Implement CRUD Endpoints for Pokemon
// A. GET /pokemon 
app.MapGet("/pokemon", () =>
{
    return pokemons;
});


// B. GET /pokemon/{id} 
app.MapGet("/pokemon/{id}", (int id) =>
{
    var pokemon = pokemons.FirstOrDefault(p => p.Id == id);

    return pokemon is not null
        ? Results.Ok(pokemon)
        : Results.NotFound($"Pokemon with ID {id} not found.");
});


// C. POST /pokemon 
app.MapPost("/pokemon", (Pokemon p) =>
{
    p.Id = pokemons.Count == 0 ? 1 : pokemons.Max(x => x.Id) + 1;

    pokemons.Add(p);

    return Results.Created($"/pokemon/{p.Id}", p);
});

// D. DELETE /pokemon/{id}
app.MapDelete("/pokemon/{id}", (int id) =>
{
    var pokemon = pokemons.FirstOrDefault(p => p.Id == id);

    if (pokemon is null)
        return Results.NotFound($"Pokemon with ID {id} does not exist.");

    pokemons.Remove(pokemon);

    return Results.Ok(pokemons);
});

// 4. Add an API to Train a Pokemon
//  POST /pokemon/{name}/train/{amount}
app.MapPut("/pokemon/{name}/train/{amount}", (string name, int amount) =>
{
    var pokemon = pokemons.FirstOrDefault(p =>
        p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (pokemon is null)
        return Results.NotFound($"Pokemon '{name}' not found.");

    pokemon.GainExperience(amount);

    return Results.Ok(pokemon);
});

app.Run();


