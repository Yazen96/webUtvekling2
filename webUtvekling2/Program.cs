using Microsoft.EntityFrameworkCore;
using webUtvekling2.Models;

var builder = WebApplication.CreateBuilder(args);

// L�gg till databaskontext (EF Core)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Minimal API endpoints
app.MapGet("/bocker", async (AppDbContext db) => await db.Böckers.ToListAsync());
app.MapGet("/bocker/{id}", async (AppDbContext db, string id) => await db.Böckers.FindAsync(id) is Böcker bocker ? Results.Ok(bocker) : Results.NotFound());
app.MapPost("/bocker", async (AppDbContext db, Böcker bocker) => { db.Böckers.Add(bocker); await db.SaveChangesAsync(); return Results.Created($"/bocker/{bocker.Isbn13}", bocker); });
app.MapPut("/bocker/{id}", async (AppDbContext db, string id, Böcker updatedBocker) => { var bocker = await db.Böckers.FindAsync(id); if (bocker is null) return Results.NotFound(); db.Entry(bocker).CurrentValues.SetValues(updatedBocker); await db.SaveChangesAsync(); return Results.NoContent(); });
app.MapDelete("/bocker/{id}", async (AppDbContext db, string id) => { var bocker = await db.Böckers.FindAsync(id); if (bocker is not null) { db.Böckers.Remove(bocker); await db.SaveChangesAsync(); return Results.NoContent(); } return Results.NotFound(); });

app.MapGet("/butiker", async (AppDbContext db) => await db.Butikers.ToListAsync());
app.MapGet("/butiker/{id}", async (AppDbContext db, int id) => await db.Butikers.FindAsync(id) is Butiker butiker ? Results.Ok(butiker) : Results.NotFound());
app.MapPost("/butiker", async (AppDbContext db, Butiker butiker) => { db.Butikers.Add(butiker); await db.SaveChangesAsync(); return Results.Created($"/butiker/{butiker.Id}", butiker); });
app.MapPut("/butiker/{id}", async (AppDbContext db, int id, Butiker updatedButiker) => { var butiker = await db.Butikers.FindAsync(id); if (butiker is null) return Results.NotFound(); db.Entry(butiker).CurrentValues.SetValues(updatedButiker); await db.SaveChangesAsync(); return Results.NoContent(); });
app.MapDelete("/butiker/{id}", async (AppDbContext db, int id) => { var butiker = await db.Butikers.FindAsync(id); if (butiker is not null) { db.Butikers.Remove(butiker); await db.SaveChangesAsync(); return Results.NoContent(); } return Results.NotFound(); });

app.MapGet("/forfattare", async (AppDbContext db) => await db.Författares.ToListAsync());
app.MapGet("/forfattare/{id}", async (AppDbContext db, int id) => await db.Författares.FindAsync(id) is Författare forfattare ? Results.Ok(forfattare) : Results.NotFound());
app.MapPost("/forfattare", async (AppDbContext db, Författare forfattare) => { db.Författares.Add(forfattare); await db.SaveChangesAsync(); return Results.Created($"/forfattare/{forfattare.Id}", forfattare); });
app.MapPut("/forfattare/{id}", async (AppDbContext db, int id, Författare updatedForfattare) => { var forfattare = await db.Författares.FindAsync(id); if (forfattare is null) return Results.NotFound(); db.Entry(forfattare).CurrentValues.SetValues(updatedForfattare); await db.SaveChangesAsync(); return Results.NoContent(); });
app.MapDelete("/forfattare/{id}", async (AppDbContext db, int id) => { var forfattare = await db.Författares.FindAsync(id); if (forfattare is not null) { db.Författares.Remove(forfattare); await db.SaveChangesAsync(); return Results.NoContent(); } return Results.NotFound(); });

app.MapGet("/kunder", async (AppDbContext db) => await db.Kunders.ToListAsync());
app.MapGet("/kunder/{id}", async (AppDbContext db, int id) => await db.Kunders.FindAsync(id) is Kunder kunder ? Results.Ok(kunder) : Results.NotFound());
app.MapPost("/kunder", async (AppDbContext db, Kunder kunder) => { db.Kunders.Add(kunder); await db.SaveChangesAsync(); return Results.Created($"/kunder/{kunder.Id}", kunder); });
app.MapPut("/kunder/{id}", async (AppDbContext db, int id, Kunder updatedKunder) => { var kunder = await db.Kunders.FindAsync(id); if (kunder is null) return Results.NotFound(); db.Entry(kunder).CurrentValues.SetValues(updatedKunder); await db.SaveChangesAsync(); return Results.NoContent(); });
app.MapDelete("/kunder/{id}", async (AppDbContext db, int id) => { var kunder = await db.Kunders.FindAsync(id); if (kunder is not null) { db.Kunders.Remove(kunder); await db.SaveChangesAsync(); return Results.NoContent(); } return Results.NotFound(); });

app.MapGet("/lagersaldo", async (AppDbContext db) => await db.LagerSaldos.ToListAsync());
app.MapGet("/lagersaldo/{butikId}/{isbn}", async (AppDbContext db, int butikId, string isbn) => await db.LagerSaldos.FindAsync(butikId, isbn) is LagerSaldo lagersaldo ? Results.Ok(lagersaldo) : Results.NotFound());
app.MapPost("/lagersaldo", async (AppDbContext db, LagerSaldo lagersaldo) => { db.LagerSaldos.Add(lagersaldo); await db.SaveChangesAsync(); return Results.Created($"/lagersaldo/{lagersaldo.ButikId}/{lagersaldo.Isbn}", lagersaldo); });
app.MapPut("/lagersaldo/{butikId}/{isbn}", async (AppDbContext db, int butikId, string isbn, LagerSaldo updatedLagersaldo) => { var lagersaldo = await db.LagerSaldos.FindAsync(butikId, isbn); if (lagersaldo is null) return Results.NotFound(); db.Entry(lagersaldo).CurrentValues.SetValues(updatedLagersaldo); await db.SaveChangesAsync(); return Results.NoContent(); });
app.MapDelete("/lagersaldo/{butikId}/{isbn}", async (AppDbContext db, int butikId, string isbn) => { var lagersaldo = await db.LagerSaldos.FindAsync(butikId, isbn); if (lagersaldo is not null) { db.LagerSaldos.Remove(lagersaldo); await db.SaveChangesAsync(); return Results.NoContent(); } return Results.NotFound(); });

app.MapGet("/orderdetaljer", async (AppDbContext db) => await db.Orderdetaljers.ToListAsync());
app.MapGet("/orderdetaljer/{orderId}/{isbn}", async (AppDbContext db, int orderId, string isbn) => await db.Orderdetaljers.FindAsync(orderId, isbn) is Orderdetaljer orderdetaljer ? Results.Ok(orderdetaljer) : Results.NotFound());
app.MapPost("/orderdetaljer", async (AppDbContext db, Orderdetaljer orderdetaljer) => { db.Orderdetaljers.Add(orderdetaljer); await db.SaveChangesAsync(); return Results.Created($"/orderdetaljer/{orderdetaljer.OrderId}/{orderdetaljer.Isbn}", orderdetaljer); });
app.MapPut("/orderdetaljer/{orderId}/{isbn}", async (AppDbContext db, int orderId, string isbn, Orderdetaljer updatedOrderdetaljer) => { var orderdetaljer = await db.Orderdetaljers.FindAsync(orderId, isbn); if (orderdetaljer is null) return Results.NotFound(); db.Entry(orderdetaljer).CurrentValues.SetValues(updatedOrderdetaljer); await db.SaveChangesAsync(); return Results.NoContent(); });
app.MapDelete("/orderdetaljer/{orderId}/{isbn}", async (AppDbContext db, int orderId, string isbn) => { var orderdetaljer = await db.Orderdetaljers.FindAsync(orderId, isbn); if (orderdetaljer is not null) { db.Orderdetaljers.Remove(orderdetaljer); await db.SaveChangesAsync(); return Results.NoContent(); } return Results.NotFound(); });

app.MapGet("/ordrar", async (AppDbContext db) => await db.Ordrars.ToListAsync());
app.MapGet("/ordrar/{id}", async (AppDbContext db, int id) => await db.Ordrars.FindAsync(id) is Ordrar ordrar ? Results.Ok(ordrar) : Results.NotFound());
app.MapPost("/ordrar", async (AppDbContext db, Ordrar ordrar) => { db.Ordrars.Add(ordrar); await db.SaveChangesAsync(); return Results.Created($"/ordrar/{ordrar.Id}", ordrar); });
app.MapPut("/ordrar/{id}", async (AppDbContext db, int id, Ordrar updatedOrdrar) => { var ordrar = await db.Ordrars.FindAsync(id); if (ordrar is null) return Results.NotFound(); db.Entry(ordrar).CurrentValues.SetValues(updatedOrdrar); await db.SaveChangesAsync(); return Results.NoContent(); });
app.MapDelete("/ordrar/{id}", async (AppDbContext db, int id) => { var ordrar = await db.Ordrars.FindAsync(id); if (ordrar is not null) { db.Ordrars.Remove(ordrar); await db.SaveChangesAsync(); return Results.NoContent(); } return Results.NotFound(); });

app.Run();