namespace User.Auth
{
    public class MyTokenResponse : TokenResponse
    {
        //ideally should be using something like nodatime to convert to the local time zone of the client app
        public string AccessTokenExpiry => AccessExpiry.ToLocalTime().ToString();

        public int RefreshTokenValidityMinutes => (int)RefreshExpiry.Subtract(DateTime.UtcNow).TotalMinutes;

        //NOTE: most of the time you will be doing this kind of custom transformation on the expiry datetime properties.
        //      that is why the TokenResponse properties are decorated with [JsonIgnore] attributes.
    }
}
