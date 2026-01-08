using Models;
using DTOs.Categories;

namespace Endpoints
{
    public static class CategoryEndpoints
    {
        public static void AddCategoryEndpoints(this WebApplication app)
        {
            app.MapPost("/category", CreateCategory);
            app.MapGet("/category/{id}", GetCategory);
            app.MapGet("/category", GetCategoryTEST);
        }

        private static async Task<IResult> CreateCategory(CreateCategoryRequest request, AppDbContext db)
        {
            // EF entity
            var categoryEntity = new Category
            {
                Name = request.Name
            };

            // when this happens category above gets the id auto assigned
            db.Categories.Add(categoryEntity);
            await db.SaveChangesAsync();

            // Factory pattern
            return TypedResults.Created(
                $"/category/{categoryEntity.Id}", 
                new CategoryResponse(
                    categoryEntity.Id,
                    categoryEntity.Name
                )
            );
        }

        private static async Task<IResult> GetCategory(int id, AppDbContext db)
        {
            return await db.Categories.FindAsync(id)
                is Category category
                    ? TypedResults.Ok(new CategoryResponse(category.Id, category.Name))
                    : TypedResults.NotFound();
        }

        private static async Task<IResult> GetCategoryTEST(AppDbContext db)
        {
            return await db.Categories.FindAsync(1)
                is Category category
                    ? TypedResults.Ok(new CategoryResponse(category.Id, category.Name))
                    : TypedResults.NotFound();
        }
    }
}