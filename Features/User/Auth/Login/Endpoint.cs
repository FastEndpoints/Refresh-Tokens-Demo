using User.Auth.RefreshToken;

namespace User.Auth.Login;

public class Endpoint : Endpoint<Request, TokenResponse>
{
    public override void Configure()
    {
        Post("user/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var userID = await Data.GetUserID(r.Email, r.Password);

        if (string.IsNullOrEmpty(userID))
            ThrowError("Invalid user credentials!");

        Response = await CreateTokenWith<UserTokenService>(userID, p =>
        {
            p.Claims.Add(new("UserID", userID));
            p.Permissions.AddRange(new Allow().AllCodes());
        });
    }
}