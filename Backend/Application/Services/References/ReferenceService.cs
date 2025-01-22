using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.References;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Common;
using Application.Services.References.Validators;

namespace Application.Services.References;

public class ReferenceService : IReferenceService
{
    private readonly IReferenceRepository _referenceRepository;

    public ReferenceService(IReferenceRepository referenceRepository)
    {
        _referenceRepository = referenceRepository;
    }

    public async Task<int> AddReferenceAsync(CreateManyReferenceDto references)
    {
        CreateManyReferenceValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(references));
        if (references == null || references.References.Count == 0)
        {
            throw new CommandExecutionException("References cannot be null or empty");
        }

        return await _referenceRepository.AddReferenceAsync(references);
    }

    public async Task<int> DeleteReferenceAsync(Guid id)
    {
        return await _referenceRepository.DeleteReferenceAsync(id);
    }

    public async Task<int> DeleteReferenceByInfoIdAsync(Guid infoId)
    {
        return await _referenceRepository.DeleteReferenceByInfoIdAsync(infoId);
    }

    public async Task<GetManyReferenceDto> GetReferencesByInfoIdAsync(Guid infoId)
    {
        return await _referenceRepository.GetReferencesByInfoIdAsync(infoId);
    }

    public async Task<int> UpdateReferenceAsync(UpdateReferenceDto reference)
    {
        UpdateReferenceValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(reference));
        return await _referenceRepository.UpdateReferenceAsync(reference);
    }
}
