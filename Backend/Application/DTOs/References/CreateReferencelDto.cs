namespace Application.DTOs.References;

public class CreateReferenceDto
{
    public required string Name { get; set; }
    public required string Position { get; set; }
    public required string WorkPlace { get; set; }
    public string? ContactInfo { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
}
