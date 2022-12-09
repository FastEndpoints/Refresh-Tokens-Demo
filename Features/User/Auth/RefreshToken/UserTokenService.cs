namespace User.Auth.RefreshToken;

public class UserTokenService : RefreshTokenService<TokenRequest, TokenResponse>
{
    public UserTokenService(IConfiguration config)
    {
        Setup(x =>
        {
            x.TokenSigningKey = config["JWTSigningKey"];
            x.AccessTokenValidity = TimeSpan.FromMinutes(1);
            x.RefreshTokenValidity = TimeSpan.FromHours(1);
            x.Endpoint("/user/auth/refresh-token", ep =>
            {
                ep.Summary(s => s.Description = "this is the refresh token endpoint");
            });
        });
    }

    public override Task PersistTokenAsync(TokenResponse rsp)
    {
        return Data.StoreToken(rsp.UserId, rsp.RefreshExpiry, rsp.RefreshToken);
    }

    public override async Task RefreshRequestValidationAsync(TokenRequest req)
    {
        if (!await Data.TokenIsValid(req.UserId, req.RefreshToken))
            AddError("The refresh token is not valid!");
    }

    public override Task SetRenewalPrivilegesAsync(TokenRequest request, UserPrivileges privileges)
    {
        privileges.Claims.Add(new("UserID", request.UserId));
        privileges.Permissions.AddRange(new Allow().AllCodes());
        return Task.CompletedTask;
    }
}