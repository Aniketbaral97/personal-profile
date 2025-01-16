namespace Application.DTOs.Skills;

public class CreateManySkillDto
{
     public Guid PersonalInfoId { get; set; }
     public List<CreateSkillDto> Skills { get; set; }=[];
}
