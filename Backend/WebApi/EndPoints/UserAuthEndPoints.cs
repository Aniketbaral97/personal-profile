using Application.DTOs.Identity;
using Domain.Enums;
using Application.Interfaces;
using Application.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.EndPoints;

public static class UserEndPoints
{
    public static RouteGroupBuilder MapUserAuthApi(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/auth").WithTags("Auth");
        group.MapPost("/login", async([FromBody] LoginRequestModel requestModel,[FromServices] IIdentityService identityService, 
            [FromServices] JwtTokenService tokenService)=>{
                  var response  = new ResultModel<string>();
            UserDto user = await identityService.FindByUserName(requestModel.UserName);
            if (user.UserName!=requestModel.UserName)
            {

                response.Errors.Add("The user you are trying to log in does not exist.");
                return response;
            }
            if (user.IsActive==ActiveStatus.Inactive)
            {

                response.Errors.Add("You are trying to login Inactive user");
                return response;
            }

            var isAuthenticated = await identityService.Authenticate(requestModel.UserName, requestModel.Password);
            if (!isAuthenticated)
            {
                response.Errors.Add("Invalid User Credentials");
                return response;
            }
            var claims = await identityService.GetUserClaims(user.Id);
            var token = tokenService.GenerateJSONWebToken(user, claims.ToList());
            response.SuccessResult(token);
            return response;
            
        });
        return group;
    }
    
}
