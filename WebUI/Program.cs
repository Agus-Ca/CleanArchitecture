using Application;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuracion de cors
string CorsAllowed = "CorsAllowed";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsAllowed, builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddMediatR(typeof(ApplicationMediatREntryPoint).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsAllowed);

app.UseAuthorization();

app.MapControllers();

app.Run();