using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Înregistrăm contextul pentru aplicație
builder.Services.AddDbContext<CinemaAplicatieWEBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaAplicatieWEBContext")));

// Configurăm autentificarea cu cookie-uri
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Calea către pagina de login
        options.LogoutPath = "/Logout"; // Calea către pagina de logout
    });

// Adăugăm suport pentru autorizare
builder.Services.AddAuthorization();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Activăm autentificarea și autorizarea
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
