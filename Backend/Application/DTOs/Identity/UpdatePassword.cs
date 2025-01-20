namespace Application.DTOs.Identity;
public class UpdatePassword
{
    public Guid Id { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
}

public class ExternalUpdatePassword
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
