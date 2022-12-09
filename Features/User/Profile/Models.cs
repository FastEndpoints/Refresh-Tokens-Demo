#pragma warning disable CS8618
using FluentValidation;

namespace User.Profile;

public class Request
{
    [FromClaim("UserID")]
    public string UserID { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserID).NotEmpty();
    }
}

public class Response
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}
