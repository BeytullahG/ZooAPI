using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ZooDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/animals", (IAnimalService service) =>
{
    return Results.Ok(service.GetAll());
});

app.MapGet("/api/animals/{id}", (IAnimalService service, int id) =>
{
    var animal = service.GetById(id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    else return Results.Ok(animal);

});

app.MapPost("/api/animals", (IAnimalService service, Animal animal) =>
{
    var created = service.Create(animal);

    return Results.Created($"/api/animals/{created.Id}", created);
});


app.MapPut("/api/animals/{id}/feed", (int id, int food, IAnimalService service) =>
{
    if (food < 1 || food > 100) return Results.BadRequest();
    var an = service.Feed(id, food);
    if (an) return Results.Ok();
    else return Results.NotFound();
});

app.MapDelete("/api/animals/{id}", (int id, IAnimalService service)=>
{
    var an = service.Delete(id);
    if (an) return Results.NoContent();
    else return Results.NotFound();
});

app.Run();
