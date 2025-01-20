using Domain.Enums;
using WebApi.Models;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs.Identity;

namespace WebApi.EndPoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoint(this IEndpointRouteBuilder routes){
        var group = routes.MapGroup("/api/user").WithTags("Users").RequireAuthorization();
        group.MapPost("/", async([FromServices] IIdentityService service, AddUser request )=>{
            var response = new ResultModel<Guid>();
            try
            {
                var res = await service.Create(request);
                response.SuccessResult(res);

            }
            catch (ValidationServiceException e)
            {
                response.Errors = e.ErrorMessages;
            }
            catch (CommandExecutionException ex)
            {
                response.Errors.Add(ex.Message);
            }
            return Results.Ok(response);
        });
        group.MapPut("/{id:guid}", async ([FromServices] IIdentityService service,
            Guid id,
            EditUser request
            ) =>
        {
            var response = new ResultModel<Guid>();
            try
            {
                if (id == request.Id)
                {
                    var res = await service.Update(request);
                    response.SuccessResult(res);
                }
                else
                {
                    response.Errors.Add("Requested Id does not match");
                }
            }
            catch (ValidationServiceException e)
            {
                response.Errors = e.ErrorMessages;
            }
            catch (CommandExecutionException ex)
            {
                response.Errors.Add(ex.Message);
            }
            return Results.Ok(response);

        });
        group.MapDelete("/{id:guid}", async ([FromServices] IIdentityService service,
            Guid id
            ) =>
        {
            var response = new ResultModel<bool>();
            try
            {
                var res = await service.Delete(id);
                response.SuccessResult(res);

            }
            catch (CommandExecutionException ex)
            {
                response.Errors.Add(ex.Message);
            }
            return Results.Ok(response);

        });
        group.MapGet("/list", async (int offset,
        Guid projectId,
        string? username,
        UserGroup? userGroup,
        ActiveStatus? activeStatus,
        [FromServices] IIdentityService service)
        =>
        {
            var request = new UserListQueryRequest
            {
                Offset = offset,
                Filter = new UserListQueryRequest.UserListQueryRequestFilter
                {
                    ProjectId = projectId,
                    Username = username,
                    UserGroup = userGroup,
                    ActiveStatus = activeStatus
                }
            };
            return await service.FindAll(request);
        });
        group.MapGet("/{id:guid}", async ([FromServices] IIdentityService service,
            Guid id
            ) =>
        {
            System.Console.WriteLine("Id:"+id);
            return Results.Ok(await service.GetById(id));
        });

        group.MapPut("/update-password", async ([FromServices] IIdentityService service,
            UpdatePassword request
            ) =>
        {
            var response = new ResultModel<bool>();
            try
            {
                var res = await service.UpdatePassword(request);
                response.SuccessResult(res);
            }
            catch (ValidationServiceException e)
            {
                response.Errors = e.ErrorMessages;
            }
            catch (CommandExecutionException ex)
            {
                response.Errors.Add(ex.Message);
            }
            return Results.Ok(response);

        });
        
        return group;
    }
}
