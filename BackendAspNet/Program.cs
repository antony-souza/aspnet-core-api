using System.Text;
using BackendAspNet.context;
using BackendAspNet.modules.auth.usecase;
using BackendAspNet.modules.user.usecase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(DotNetEnv.Env.GetString("DATABASE_URL")));
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(DotNetEnv.Env.GetString("JWT_SECRET"))
            )
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<AuthUseCase>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();