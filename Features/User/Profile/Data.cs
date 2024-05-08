using MongoDB.Entities;

namespace User.Profile;

public static class Data
{
    public static Task<Dom.User?> GetUser(string userID)
        => DB.Find<Dom.User>()
             .MatchID(userID)
             .ExecuteSingleAsync();
}