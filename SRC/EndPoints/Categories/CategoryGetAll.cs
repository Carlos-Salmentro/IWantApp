using Microsoft.EntityFrameworkCore;
using IWantApp.Infra.Data;
using IWantApp.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();

        var response = categories.Select(c => new CategoryResponse { Name = c.Name, Active = c.Active, Id = c.Id});
        context.SaveChanges();
        return Results.Ok(response);
    }

}
