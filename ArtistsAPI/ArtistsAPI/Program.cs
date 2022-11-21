using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using SpotifyAPI.Web;

var builder = WebApplication.CreateBuilder(args);

var clientId = builder.Configuration["SpotifyAPI:ClientId"];
var clientSecret = builder.Configuration["SpotifyAPI:ClientSecret"];
var server = builder.Configuration["Cors:Server"];

// Add services to the container.
builder.Services.AddDbContext<ArtistsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArtistsDb"));
});
builder.Services.AddSingleton(SpotifyClientConfig.CreateDefault()
    .WithAuthenticator(new ClientCredentialsAuthenticator(clientId, clientSecret)));
builder.Services.AddScoped<SpotifyClientBuilder>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.UseCors(policy => {
    policy.WithOrigins(server).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
});

app.MapControllers();

app.Run();

