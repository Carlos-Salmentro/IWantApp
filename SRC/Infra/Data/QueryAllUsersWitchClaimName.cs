using Dapper;
using IWantApp.EndPoints.Employees;
using MySqlConnector;

namespace IWantApp.Infra.Data;

public class QueryAllUsersWithClaimName
{
    private readonly IConfiguration configuration;
    
    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmployeeResponse> Execute(int page, int row)
    {
        var db = new MySqlConnection(configuration["ConnectionStrings:IWantDbString"]);
        var offSet = (page - 1) * row;
        var query = @"select Email, ClaimValue as 'Name'
                     from iwantapp.aspnetusers u
                     inner join iwantapp.aspnetuserclaims c
                     on u.Id = c.UserId and c.ClaimType = 'Name'
                     ORDER BY Name
                     LIMIT @row OFFSET @offSet";
        return db.Query<EmployeeResponse>(query, new { offSet, row });
    }
}
