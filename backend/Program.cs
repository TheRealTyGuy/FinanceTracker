using Microsoft.EntityFrameworkCore;
using Endpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

//
Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
Microsoft.IdentityModel.Logging.IdentityModelEventSource.LogCompleteSecurityArtifact = true;
//

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority =
            $"https://{builder.Configuration["Auth0:Domain"]}/";

        options.Audience =
            builder.Configuration["Auth0:Audience"];
        
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("Token failed: " + context.Exception.Message);
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(o =>
    {
        o.AddPolicy("todo:read-write", p => p.
            RequireAuthenticatedUser().
            RequireClaim("scope", "todo:read-write"));
    });

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("Data source=finance.db"));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.AddAccountEndpoints();
app.AddCategoryEndpoints();
app.AddTransactionEndpoints();
app.AddUserEndpoints();

app.Run();