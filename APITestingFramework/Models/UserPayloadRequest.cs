namespace Models;
using System.Text.Json.Serialization;

public record UserPayloadModelRequest
{
    public string? Email { get; set; } = null;
    public string? Password { get; set; } = null;
    public string? FullName { get; set; } = null;

    public UserPayloadModelRequest(string Email, string FullName, string Password)
    {
        this.Email = Email;
        this.FullName = FullName;
        this.Password = Password;
    }
}


