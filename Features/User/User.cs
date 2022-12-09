#pragma warning disable CS8618
using MongoDB.Entities;

namespace Dom;

public class User : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }

    static User()
    {
        DB.Index<User>()
          .Key(x => x.Email, KeyType.Ascending)
          .Key(x => x.Password, KeyType.Ascending)
          .CreateAsync();
    }
}