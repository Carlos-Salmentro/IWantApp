using Microsoft.EntityFrameworkCore;
using IWantApp.Infra.Data;
using IWantApp.Domain.Products;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IWantApp.EndPoints.Categories;

public class CategoryEdit
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, [FromBody] CategoryRequest request, ApplicationDbContext context)
    {
        var search = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (search == null)
            return Results.NotFound(id);

        search.Edit(search, request.Name, request.Active, "EditedByTest");

        if (!search.IsValid)
            return Results.ValidationProblem(search.Notifications.ToProblemDetails());

        CategoryResponse response = new CategoryResponse { Name = search.Name, Active = search.Active };
        
        context.SaveChanges();

        return Results.Accepted(Template, response);
    }

}
