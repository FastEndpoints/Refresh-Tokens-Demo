namespace User.Profile;

public class Mapper : Mapper<Request, Response, Dom.User>
{
    public override Response FromEntity(Dom.User e) => new()
    {
        Age = e.Age,
        Email = e.Email,
        Name = e.Name
    };
}