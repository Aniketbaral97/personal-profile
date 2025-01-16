using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs.Experiences;

public class CreateExperienceDto
{
    public required string Title { get; set; }
    public required string Company { get; set; }
    public required string Position { get; set; }
    public required string Duration { get; set; }
    public required string Description { get; set; }
    public bool IsCurrent { get; set; }
    public required DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}



