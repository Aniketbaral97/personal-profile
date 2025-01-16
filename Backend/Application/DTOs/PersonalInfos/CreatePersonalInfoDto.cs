namespace Application.DTOs.PersonalInfos;

public class CreatePersonalInfoDto
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Designations { get; set; }
    public required string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Details {get;set;}
    public string? ShortText {get;set;}
}
