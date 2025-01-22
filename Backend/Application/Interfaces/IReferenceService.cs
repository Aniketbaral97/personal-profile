using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.References;

namespace Application.Interfaces;

public interface IReferenceService
{
    public Task<int> AddReferenceAsync(CreateManyReferenceDto References);
    public Task<int> UpdateReferenceAsync(UpdateReferenceDto Reference);
    public Task<int> DeleteReferenceAsync(Guid id);
    public Task<int> DeleteReferenceByInfoIdAsync(Guid infoId);
    public Task<GetManyReferenceDto> GetReferencesByInfoIdAsync(Guid infoId);
}
