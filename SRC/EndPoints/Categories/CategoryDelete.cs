using Microsoft.EntityFrameworkCore;
using IWantApp.Infra.Data;
using IWantApp.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        Category category = context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return Results.NotFound(id);
        }

        context.Categories.Remove(category);
        context.SaveChanges();
        return Results.Ok();
    }

}
