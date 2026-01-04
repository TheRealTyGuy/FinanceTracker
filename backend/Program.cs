using Microsoft.EntityFrameworkCore;
using Endpoints;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("Data source=finance.db"));

// builder.Services.
//     AddAuthentication(options =>
//     {
//         options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//     }
//     )
//     .AddCookie()
//     .AddGoogle(options =>
//     {
//         options.ClientId = builder.Configuration["Authentication__Google__ClientId"]!;
//         options.ClientSecret = builder.Configuration["Authentication__Google__ClientSecret"]!;
//         options.CallbackPath = "/login/google/callback";
//     });
// builder.Services.AddAuthorization();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseAuthentication();
// app.UseAuthorization();

// app.AddAuthenticationEndpoints();
app.AddAccountEndpoints();
app.AddCategoryEndpoints();
app.AddTransactionEndpoints();
app.AddUserEndpoints();


app.Run();