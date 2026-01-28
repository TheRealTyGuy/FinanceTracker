using Microsoft.EntityFrameworkCore;
using Endpoints;
using Models;
using DTOs.Categories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => 
                      {
                        policy.WithOrigins("http://localhost:5173")
                              .WithHeaders("Content-Type")
                              .AllowAnyMethod();
                      });
});
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("Data source=finance.db"));

builder.Services.AddAuthorization();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<User>();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.AddAccountEndpoints();
app.AddCategoryEndpoints();
app.AddTransactionEndpoints();
app.AddUserEndpoints();

app.Run();