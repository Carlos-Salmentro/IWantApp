using Flunt.Notifications;

namespace IWantApp.EndPoints;

public static class ProblemDetailExtentions
{
    public static Dictionary<string, string[]> ToProblemDetails (this IReadOnlyCollection<Notification> notification)
    {
        return notification.GroupBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Select(x => x.Message).ToArray());
    }
}
