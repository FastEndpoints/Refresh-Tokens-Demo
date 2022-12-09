namespace User.Signup;

public class Mapper : Mapper<Request, Response, Dom.User>
{
    public override Dom.User ToEntity(Request r) => new()
    {
        Age = r.Age,
        Email = r.Email,
        Password = r.Password, //never store clear passwords in db. always hash/salt before saving.
        Name = r.Name
    };
}