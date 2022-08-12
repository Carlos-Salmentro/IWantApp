using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Security;

public class TokenPost
{
    public static string Template => "/security";
    public static string[] Methods => new string[] { HttpMethods.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action()
    {

    }
}
