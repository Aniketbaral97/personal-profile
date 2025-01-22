using Application.DTOs.References;

namespace Application.Interfaces;

public interface IReferenceRepository
{
    public Task<int> AddReferenceAsync(CreateManyReferenceDto References);
    public Task<int> UpdateReferenceAsync(UpdateReferenceDto Reference);
    public Task<int> DeleteReferenceAsync(Guid id);
    public Task<int> DeleteReferenceByInfoIdAsync(Guid infoId);
    public Task<GetManyReferenceDto> GetReferencesByInfoIdAsync(Guid infoId);
}
