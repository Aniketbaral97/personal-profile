using Domain.Enums;

namespace Application.DTOs.PersonalInfos;

public class CreatePersonalInfoDto
{
    public required string Firstname { get; set; }
    public string? Middlename { get; set; }
    public required string Lastname { get; set; }
    public required string Designations { get; set; }
    public required string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Details {get;set;}
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; } = Gender.Other;
    public string? ShortText {get;set;}
    public string? Email {get;set;}
    public string? Nationality { get; set; }
    public string[] Hobbies { get; set; }=[];
    public string[] Languages { get; set; }=[];
    public WorkAvailabilityStatus WorkAvailabilityStatus {get;set;} = WorkAvailabilityStatus.Available;
}
