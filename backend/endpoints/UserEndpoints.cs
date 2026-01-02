using Models;
using DTOs;

// waiting on implementation due to intent to switch to google sso
namespace Endpoints
{
    public static class UserEndpoints
    {
        public static void AddUserEndpoints(this WebApplication app)
        {
            // app.MapPost("/user", CreateUser);
            // app.MapGet("/user/{id}", GetUser);
        }

        // Have to take in non-DTO to get all fields
        // private static async Task<IResult> CreateUser(User user, AppDbContext db)
        // {
            
        // }

        // private static async Task<IResult> GetUser(int id, AppDbContext db)
        // {
        
        // }
    }
}