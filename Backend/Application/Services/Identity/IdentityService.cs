using System.Security.Claims;
using Application.DTOs.Identity;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Application.Services.Identity;

public class IdentityService : IIdentityService
{
    private UserManager<ApplicationUser> _userManager;

    public IdentityService(
     UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    #region commands
    public async Task<Guid> Create(AddUser entity)
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            UserName = entity.UserName,
            Email = entity.Email,
            UserGroup = entity.UserGroup,
            FirstName = entity.FirstName,
            MiddleName = entity.MiddleName,
            LastName = entity.LastName,
            PasswordHash = entity.Password,
            IsActive = entity.ActiveStatus,
        };
        var isExist = await _userManager.FindByNameAsync(entity.UserName);
        var isMailExist = await _userManager.FindByEmailAsync(entity.Email);
        if (isExist is not null)
        {
            throw new CommandExecutionException($"We regret to inform you that the username {entity.UserName} is already in use. Please choose a different username to proceed with creating your account.");
        }
        if (isMailExist is not null)
        {
            throw new CommandExecutionException($"We regret to inform you that the email {entity.Email} is already in use. Please choose a different email to proceed with creating your account.");
        }
        var result = await _userManager.CreateAsync(user, entity.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => new { x.Code, x.Description }).ToList();
            Dictionary<string, string> dict = new();
            foreach (var item in errors)
            {
                dict.Add(item.Code.ToString(), item.Description.ToString());
            }

        }

        return user.Id;


    }

    public async Task<bool> Delete(Guid id)
    {
        ApplicationUser? user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            throw new CommandExecutionException("User with given id not fount");
        }
        user.LockoutEnabled = true;
        user.IsActive = ActiveStatus.Inactive;
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }
    public async Task<bool> UpdatePassword(UpdatePassword model)
    {
        var user = await _userManager.FindByIdAsync(model.Id.ToString());
        if (user == null)
        {
            return false;
        }
        var pass = model.Password.ToString();
        var confPass = model.ConfirmPassword.ToString();
        if (pass != confPass)
        {
            return false;
        }
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, pass);
        if (!result.Succeeded)
        {
            return false;
        }
        return true;
    }
    public async Task<Guid> Update(EditUser entity)
    {
        var user = await _userManager.FindByIdAsync(entity.Id.ToString());
        if (user is not null)
        {
            user.UserName = entity.UserName;
            user.UserGroup = entity.UserGroup;
            user.Email = entity.Email;
            user.FirstName = entity.FirstName;
            user.MiddleName = entity.MiddleName;
            user.LastName = entity.LastName;
            user.IsActive = entity.ActiveStatus;
            user.SecurityStamp = entity.SecurityStamp;
            await _userManager.UpdateAsync(user);
        }
        return entity.Id;
    }

    public async Task<bool> AddUserClaims(Guid userId, List<Claim> claims)
    {
        var returnUser = await FindById(userId) ?? throw new CommandExecutionException("User not fount");
        await _userManager.AddClaimsAsync(returnUser, claims);
        return true;
    }
    public async Task<bool> RemoveUserClaims(Guid userId, IList<Claim> claims)
    {
        var returnUser = await FindById(userId) ?? throw new CommandExecutionException("User not fount");
        await _userManager.RemoveClaimsAsync(returnUser, claims);
        return true;
    }


    #endregion

    #region Queries
    public async Task<ApplicationUser?> FindById(Guid userId)
    {
        return await _userManager.FindByIdAsync(userId.ToString());
    }

    public async Task<UserDto> FindByUserName(string userName)
    {

        var returnUser = await _userManager.FindByNameAsync(userName);

        if (returnUser == null)
        {
            return new UserDto();
        }
        return new UserDto
        {
            Id = returnUser.Id,
            Email = returnUser.Email,
            UserName = returnUser.UserName,
            UserGroup = returnUser.UserGroup,
            FirstName = returnUser.FirstName,
            MiddleName = returnUser.MiddleName,
            LastName = returnUser.LastName,
            IsActive = returnUser.IsActive,
        };
    }

    public async Task<EditUser> GetById(Guid id)
    {
        var entity = new EditUser()
        {
            FirstName = string.Empty,
            LastName = string.Empty,
        };
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user != null)
        {
            entity.UserName = user.UserName;
            entity.Id = user.Id;
            entity.Email = user.Email;
            entity.UserGroup = user.UserGroup;
            entity.FirstName = user.FirstName;
            entity.MiddleName = user.MiddleName;
            entity.LastName = user.LastName;
            entity.ActiveStatus = user.IsActive;
            entity.SecurityStamp = user.SecurityStamp;
        }
        System.Console.WriteLine("User:"+System.Text.Json.JsonSerializer.Serialize(user));
        return await Task.FromResult(entity);
    }



    public async Task<IList<Claim>> GetUserClaims(Guid userId)
    {
        ApplicationUser? appUser = await _userManager.FindByIdAsync(userId.ToString())
        ?? null;
        if (appUser == null)
        {
            return [];
        }
        return await _userManager.GetClaimsAsync(appUser);
    }



    public string GetUserNameById(Guid userId)
    {
        var user = _userManager.FindByIdAsync(userId.ToString()).GetAwaiter().GetResult();
        if (user == null)
        {
            return string.Empty;
        }
        return user.UserName!;
    }

    public async Task<UsersList> FindAll(UserListQueryRequest query)
    {
        UsersList model = new()
        {
            Users = []
        };
        var q = _userManager.Users.AsNoTracking();
        q = q.Where(x => x.LockoutEnabled == false);
        if (query.Filter.Username != null)
        {
            q = q.Where(x => x.UserName!.Contains(query.Filter.Username, StringComparison.CurrentCultureIgnoreCase));
        }
        if (query.Filter.UserGroup > 0)
        {
            q = q.Where(x => x.UserGroup == query.Filter.UserGroup);
        }
        if (query.Filter.ActiveStatus >= 0)
        {
            q = q.Where(x => x.IsActive == (ActiveStatus)query.Filter.ActiveStatus);
        }
        q = q.OrderBy(x => x.UserName);
        model.Users = await q.Select(x => new UserListDto
        {
            Id = x.Id,
            UserName = x.UserName!,
            ActiveStatus = x.IsActive,
            UserGroup = x.UserGroup
        }).ToListAsync();
        return model;
    }

    public async Task<bool> Authenticate(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user is null)
        {
            return false;
        }
        return await _userManager.CheckPasswordAsync(user, password);
    }

    #endregion

}
