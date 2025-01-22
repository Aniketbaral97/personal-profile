namespace Application.DTOs.References;

public class CreateManyReferenceDto
{
     public Guid PersonalInfoId { get; set; }
     public List<CreateReferenceDto> References { get; set; }=[];
}
