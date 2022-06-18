namespace Movie.Core.Config
{
    public class JwtBearerTokenSettings
    {
        public string SecretKey { get; set; }
        public string ClientSecret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpiryTimeInSeconds { get; set; }
    }
}
