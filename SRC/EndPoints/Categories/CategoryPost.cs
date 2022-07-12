using Microsoft.EntityFrameworkCore;
using IWantApp.Infra.Data;
using IWantApp.Domain.Products;

namespace IWantApp.EndPoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest request, ApplicationDbContext context) 
    {
        var category = new Category(request.Name)
        {
            Name = request.Name
        };
        

        context.Categories.Add(category);
        context.SaveChanges();
        return Results.Created($"Template/{category.Id}", category.Name + category.Id);
    }

}
