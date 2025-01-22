using Domain.Enums;

namespace Application.DTOs.PersonalInfos;

public class PersonalInfoDemo{
    public Guid Id{get;set;}
    public required string Firstname { get; set; }
    public string? Middlename { get; set; }
    public required string Lastname { get; set; }
    public required string Designations { get; set; }
    public required string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public WorkAvailabilityStatus WorkAvailabilityStatus {get;set;} = WorkAvailabilityStatus.Available;
}
public class GetPersonalInfoDemoDto{
    public int TotalPages{get;set;}
    public List<PersonalInfoDemo> PersonalInfos{get;set;}=[];
}

public class PersonalInfoDemoRequestDto{
    public int Limit{get;set;}=10;
    public int Offset{get;set;}=0;
    public string? Name{get;set;}
    public WorkAvailabilityStatus WorkAvailabilityStatus{get;set;}=0;

}