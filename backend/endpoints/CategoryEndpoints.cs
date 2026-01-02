using Models;
using DTOs;

namespace Endpoints
{
    public static class CategoryEndpoints
    {
        public static void AddCategoryEndpoints(this WebApplication app)
        {
            app.MapPost("/category", CreateCategory);
            app.MapGet("/category/{id}", GetCategory);
        }

        private static async Task<IResult> CreateCategory(CategoryDTO categoryDTO, AppDbContext db)
        {
            var category = new Category
            {
                CategoryName = categoryDTO.CategoryName
            };

            db.Categories.Add(category);
            await db.SaveChangesAsync();

            var responseCategory = new CategoryDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

            // // Factory pattern
            return TypedResults.Created($"/category/{category.Id}", responseCategory);
        }

        private static async Task<IResult> GetCategory(int id, AppDbContext db)
        {
            return await db.Categories.FindAsync(id)
                is Category category
                    ? TypedResults.Ok(new CategoryDTO(category))
                    : TypedResults.NotFound();
        }
    }
}