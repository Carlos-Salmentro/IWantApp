using Dapper;
using Flunt.Validations;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace IWantApp.EndPoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethods.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromQuery] int? page, [FromQuery] int? rows, QueryAllUsersWithClaimName query)
    {
        if (page == null || !page.HasValue)
            throw new ArgumentException("Page number must be set");
        if (rows == null || rows > 10)
            throw new ArgumentException("Row must be between 1 and 10");

        var list = query.Execute(page.Value, rows.Value);

        return Results.Ok(list);
    }
}
