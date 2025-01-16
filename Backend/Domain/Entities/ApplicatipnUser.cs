using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [MaxLength(50)]
        public string? MiddleName { get; set; } = null;
        [MaxLength(50)]
        public required string LastName { get; set; }
        public UserGroup UserGroup { get; set; }
        public ActiveStatus IsActive { get; set; }
        [MaxLength(50)]
        public string? Designation {get;set;}=null;

    }
