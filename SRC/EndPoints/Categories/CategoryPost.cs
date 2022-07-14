using Microsoft.EntityFrameworkCore;
using IWantApp.Infra.Data;
using IWantApp.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromBody] CategoryRequest request, ApplicationDbContext context)
    {
        var category = new Category(request.Name)
        {
            Name = request.Name,
            CreatedBy = "test",
            CreatedOn = DateTime.Now,
            EditedBy = "test",
            EditedOn = DateTime.Now
        };


        context.Categories.Add(category);
        context.SaveChanges();
        return Results.Created($"Template/{category.Id}", category.Name);
    }

}
