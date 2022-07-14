using Microsoft.EntityFrameworkCore;
using IWantApp.Infra.Data;
using IWantApp.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Categories;

public class CategoryEdit
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, [FromBody] CategoryRequest request, ApplicationDbContext context)
    {
        var search = context.Categories.FirstOrDefault(c => c.Id == id);
        search.Name = request.Name;
        search.Active = request.Active;
        search.EditedOn = DateTime.Now;

        CategoryResponse response = new CategoryResponse { Name = search.Name };
        context.SaveChanges();

        return Results.Accepted(Template, response);
    }

}
