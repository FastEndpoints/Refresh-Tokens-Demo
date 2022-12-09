#pragma warning disable CS8618
using MongoDB.Entities;

namespace Dom;

public class RefreshToken : Entity
{
    public string UserID { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }

    static RefreshToken()
    {
        //TTL index to automatically purge records after 1 minute once the token has expired
        DB.Index<RefreshToken>()
          .Key(x => x.ExpiryDate, KeyType.Ascending)
          .Option(x => x.ExpireAfter = TimeSpan.FromMinutes(1))
          .CreateAsync();

        //compound index for queries
        DB.Index<RefreshToken>()
          .Key(x => x.UserID, KeyType.Ascending)
          .Key(x => x.Token, KeyType.Ascending)
          .Key(x => x.ExpiryDate, KeyType.Ascending)
          .CreateAsync();
    }
}