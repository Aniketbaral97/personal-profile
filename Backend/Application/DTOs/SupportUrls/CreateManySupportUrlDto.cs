namespace Application.DTOs.SupportUrls;

public class CreateManySupportUrlDto
{
    public Guid PersonalInfoId { get; set; }
    public List<CreateSupportUrlDto> SupportUrls { get; set; }=[];
}
