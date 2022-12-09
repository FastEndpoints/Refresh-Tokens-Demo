using MongoDB.Entities;

namespace User.Signup;

public static class Data
{
    public static async Task<string> CreateUser(Dom.User user)
    {
        await user.SaveAsync();
        return user.ID;
    }
}
