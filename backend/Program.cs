using Microsoft.EntityFrameworkCore;
using Endpoints;
using Models;
using DTOs.Categories;

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthentication();
app.UseAuthorization();

app.AddAccountEndpoints();
app.AddCategoryEndpoints();
app.AddTransactionEndpoints();
app.AddUserEndpoints();

app.Run();