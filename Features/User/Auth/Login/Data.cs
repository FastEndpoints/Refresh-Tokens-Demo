using MongoDB.Entities;

namespace User.Auth.Login;

public static class Data
{
    public static async Task<string?> GetUserID(string email, string password)
    {
        return await DB.Find<Dom.User, string>()
                       .Match(u => u.Email == email && u.Password == password) //never store clear text passwords in db
                       .Project(u => u.ID)
                       .ExecuteSingleAsync();
    }
}