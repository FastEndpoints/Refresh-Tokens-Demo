using MongoDB.Entities;

namespace User.Auth.RefreshToken;

public static class Data
{
    public static async Task StoreToken(string userId, DateTime refreshExpiry, string refreshToken)
    {
        await DB.DeleteAsync<Dom.RefreshToken>(rt => rt.UserID == userId);

        await new Dom.RefreshToken
        {
            UserID = userId,
            ExpiryDate = refreshExpiry,
            Token = refreshToken
        }.SaveAsync();
    }

    public static Task<bool> TokenIsValid(string userId, string refreshToken)
    {
        return DB.Find<Dom.RefreshToken>()
                 .Match(t => t.UserID == userId &&
                             t.Token == refreshToken &&
                             t.ExpiryDate >= DateTime.UtcNow)
                 .ExecuteAnyAsync();
    }
}
