using GestaoOscAPI.Repositories;
using GestaoOscAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter()
        );
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(); 

builder.Services.AddSingleton<UsuarioRepository>();
builder.Services.AddSingleton<OscRepository>();
builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<OscService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); 
app.UseHttpsRedirection();
app.MapControllers();

app.Run();