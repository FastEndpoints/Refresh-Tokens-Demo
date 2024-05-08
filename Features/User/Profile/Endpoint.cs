namespace User.Profile;

using Auth;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Get("/user/profile");
        Permissions(Allow.User_Profile_View);
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var user = await Data.GetUser(r.UserID);

        if (user is null)
            await SendNotFoundAsync();
        else
            await SendAsync(Map.FromEntity(user));
    }
}