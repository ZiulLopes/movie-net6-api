using System.Text.Json.Serialization;

namespace Movie.Core.Request
{
    public class LoginRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
