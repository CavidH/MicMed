using Clinic.API.DAL;
using Clinic.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<AppDbContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("Default")));



builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
 
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false; //@ * gibi karakterler olmalı

    options.Lockout.MaxFailedAccessAttempts = 15; //5 girişten sonra kilitlenioyr. 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(5); //5 dk sonra açılır
    options.Lockout.AllowedForNewUsers = true; //üsttekilerle alakalı

    //options.User.AllowedUserNameCharacters = ""; //olmasını istediğiniz kesin karaterrleri yaz

    options.User.RequireUniqueEmail = true; //unique emaail adresleri olsun her kullanıcının 

    options.SignIn.RequireConfirmedEmail = false; //Kayıt olduktan email ile token gönderecek 
    options.SignIn.RequireConfirmedPhoneNumber = false; //telefon doğrulaması
});


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
