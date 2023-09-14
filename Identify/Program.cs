using Identify.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
  
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

// Add services to the container.
if (connectionString == null)
{
    builder.Services.AddDbContext<PersonContext>(option =>
     option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: sqloption =>
     {
         sqloption.EnableRetryOnFailure();
     })
    );
}
else
{
    builder.Services.AddDbContext<PersonContext>(options =>
        options.UseNpgsql(connectionString));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PersonContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
