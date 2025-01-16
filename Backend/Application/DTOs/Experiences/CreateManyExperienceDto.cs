namespace Application.DTOs.Experiences;

public class CreateManyExperienceDto
{
    public Guid PersonalInfoId { get; set; }
    public List<CreateExperienceDto> Experiences { get; set; } = [];
}



