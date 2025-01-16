namespace Application.DTOs.Educations;

public class CreateManyEducationDto
{
    public Guid PersonalInfoId { get; set; }
    public List<CreateEducationDto> Educations { get; set; } = [];
}



