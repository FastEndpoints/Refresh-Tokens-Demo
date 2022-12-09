namespace User.Signup;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/user/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var userID = await Data.CreateUser(Map.ToEntity(r));

        if (string.IsNullOrEmpty(userID))
            ThrowError("User creation failed!");

        Response.Message = $"The user [{r.Name}] has been created with ID: {userID}";
    }
}