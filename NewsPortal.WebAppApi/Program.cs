
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NewsPortal.WebAppApi.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(
    option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    )
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = "https://localhost:7021",//Saj�t localhost PORTJ�T �rd be, kb nem fog m�k�dni
                ValidAudience = "https://localhost:7021",//Saj�t localhost PORTJ�T �rd be, kb nem fog m�k�dni
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))

            };
        }
    );
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
