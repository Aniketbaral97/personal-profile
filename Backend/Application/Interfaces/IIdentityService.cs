using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs.Identity;
using Domain.Entities;

namespace Application.Interfaces;

public interface IIdentityService
{
    Task<bool> AddUserClaims(Guid userId, List<Claim> claims);
    Task<bool> Authenticate(string userName, string password);
    Task<Guid> Create(AddUser entity);
    Task<bool> Delete(Guid id);
    Task<UsersList> FindAll(UserListQueryRequest query);
    Task<ApplicationUser?> FindById(Guid userId);
    Task<UserDto> FindByUserName(string userName);
    Task<EditUser> GetById(Guid id);
    Task<IList<Claim>> GetUserClaims(Guid userId);
    string GetUserNameById(Guid userId);
    Task<bool> RemoveUserClaims(Guid userId, IList<Claim> claims);
    Task<Guid> Update(EditUser entity);
    Task<bool> UpdatePassword(UpdatePassword model);
}