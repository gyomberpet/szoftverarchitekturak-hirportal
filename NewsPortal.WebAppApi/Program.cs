
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

                ValidIssuer = "https://localhost:7021",//Saját localhost PORTJÁT írd be, kb nem fog müködni
                ValidAudience = "https://localhost:7021",//Saját localhost PORTJÁT írd be, kb nem fog müködni
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))

            };
        }
    );
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

//Dataseeding start
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;



var dbContext = services.GetRequiredService<DataContext>();
dbContext.Database.EnsureCreated();

if (!dbContext.News.Any())
{
    var Newses = new List<News>
        {
            new News {Title = "DummyNews 1", Subtitle = "Something1", Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", IsTrending=false },
            new News {Title = "DummyNews 2", Subtitle = "Something2", Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", IsTrending=false },
            new News {Title = "DummyNews 3", Subtitle = "Something3", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", IsTrending = true},
        };

    dbContext.News.AddRange(Newses);
    dbContext.SaveChanges();
}
if (!dbContext.Users.Any())
{
    var Users = new List<User>
        {
            new User {UserName = "gipszjakab", EmailAddress = "admin@kft.hu", Password = "1234",  IsAdmin = true },
            new User {UserName = "shrek", EmailAddress = "onion@nasa.gov", Password = "1234",  IsAdmin = false }
        };

    dbContext.Users.AddRange(Users);
    dbContext.SaveChanges();
}
//Dataseeding end
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
