using Microsoft.EntityFrameworkCore;
using SocialHub.Domain.Respositories.Interfaces;
using SocialHub.Infrastructure.Data;
using SocialHubAPI.UseCases;
using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var key = GenerateSecretKey(64); // 64 caracteres
        Console.WriteLine($"JWT Secret Key: {key}");

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("SocialHubAPI") // Substitua "SocialHubAPI" pelo nome correto do projeto
            )
        );


        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<RegisterUserUseCase>();
        builder.Services.AddScoped<LoginUserUseCase>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", policy =>
            {
                policy.WithOrigins("http://localhost:4200") // Permitir o front-end Angular
                      .AllowAnyHeader() // Permitir todos os cabeçalhos
                      .AllowAnyMethod(); // Permitir todos os métodos (GET, POST, etc.)
            });
        });

        builder.Services.AddSingleton<TokenService>();


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowSpecificOrigin");

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    static string GenerateSecretKey(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=-";
        var random = new RNGCryptoServiceProvider();
        var buffer = new byte[length];
        random.GetBytes(buffer);
        var key = new char[length];

        for (int i = 0; i < length; i++)
        {
            key[i] = chars[buffer[i] % chars.Length];
        }

        return new string(key);
    }
}