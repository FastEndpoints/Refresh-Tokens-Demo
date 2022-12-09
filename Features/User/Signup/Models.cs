#pragma warning disable CS8618
using FluentValidation;

namespace User.Signup;

public class Request
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).MinimumLength(5);
        RuleFor(x => x.Password).MinimumLength(5).MaximumLength(20);
        RuleFor(x => x.Age).GreaterThan(15);
    }
}

public class Response
{
    public string Message { get; set; }
}
