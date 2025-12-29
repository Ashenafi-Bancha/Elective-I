var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndPointsExplorer();
builder.Services.AddSwaggerGen();





