using System.Text.Json.Serialization;

namespace AuthorizationLayer.Models;

public class AuthModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
