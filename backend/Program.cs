using Microsoft.EntityFrameworkCore;
using Endpoints;
using Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => 
                      {
                        policy.WithOrigins("http://localhost:5173")
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials();
                      });
});

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("Data source=finance.db"));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<User>();

app.AddAccountEndpoints();
app.AddCategoryEndpoints();
app.AddTransactionEndpoints();
app.AddUserEndpoints();

app.Run();