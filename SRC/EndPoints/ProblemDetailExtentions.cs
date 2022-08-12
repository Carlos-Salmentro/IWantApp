using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.EndPoints;

public static class ProblemDetailExtentions
{
    public static Dictionary<string, string[]> ToProblemDetails (this IReadOnlyCollection<Notification> notification)
    {
        return notification.GroupBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Select(x => x.Message).ToArray());
    }
    
    public static Dictionary<string, string[]> ToProblemDetails (this IEnumerable<IdentityError> error)
    {
        var dictionary = new Dictionary<string, string[]>();
        dictionary.Add("Error: ", error.Select(x => x.Description).ToArray());

        return dictionary;
    }
}
