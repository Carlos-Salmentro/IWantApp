using System.Security.Claims;
using IWantApp.Infra.Data;
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
            return Results.BadRequest(result.Errors.FirstOrDefault());

        var claimResult = userManager.AddClaimAsync(user, new Claim("EmployeeCode", request.Code)).Result;
        if (!claimResult.Succeeded)
            return Results.BadRequest(claimResult.Errors.First());

        claimResult = userManager.AddClaimAsync(user, new Claim("Name", request.Name)).Result;
        if (!claimResult.Succeeded)
            return Results.BadRequest(claimResult.Errors.First());

        return Results.Created($"Template/{user.Id}", user.Id);
    }
}
