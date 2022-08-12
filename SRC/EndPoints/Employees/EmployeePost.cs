using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Employees;

public class EmployeePost
{
    public static  string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    
    //create an user
    public static IResult Action([FromBody]EmployeeRequest request, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser { UserName = request.Email, Email = request.Email };

        var result = userManager.CreateAsync(user, request.Password).Result;

        if (result != IdentityResult.Success)
            return Results.ValidationProblem(result.Errors.ToProblemDetails());

        var claimsList = new List<Claim>
        {
            new Claim("EmployeeCode", request.Code),
            new Claim("Name", request.Name)
        };
            
       var claimResult = userManager.AddClaimsAsync(user, claimsList).Result;
        if (!claimResult.Succeeded)
            return Results.ValidationProblem(claimResult.Errors.ToProblemDetails());

        return Results.Created($"Template/{user.Id}", user.Id);
    }
}
