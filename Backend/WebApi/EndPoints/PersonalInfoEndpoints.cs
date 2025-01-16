using Application.DTOs.PersonalInfos;
using Application.Interfaces;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.EndPoints;


public static class PersonalInfoEndpoints
{
    public static RouteGroupBuilder MapPersonalInfoApi(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/personal-info")
        .WithTags("PersonalInfo")
        .RequireAuthorization();

        group.MapGet("/{id:guid}", async (Guid id,
        IPersonalInfoService repo) =>
        {
            var response = await repo.GetPersonalInfoByIdAsync(id);
            return Results.Ok(response);
        });
        
        group.MapPost("/", async (CreatePersonalInfoDto command,
        IPersonalInfoService service)
         =>
         {
             var response = new ResultModel<Guid>();
             try
             {
                 var res = await service.AddPersonalInfoAsync(command);
                 response.SuccessResult(res);

             }
             catch (ValidationException e)
             {
                 response.Errors = e.ErrorsList;
             }
             catch (CommandExecutionException ex)
             {
                 response.Errors.Add(ex.Message);
             }
             return Results.Ok(response);
         });

        group.MapPut("/{id:guid}", async (Guid id,
        [FromBody] UpdatePersonalInfoDto cmd, IPersonalInfoService service)
        =>
        {
            var response = new ResultModel<int>();
            try
            {
                var res = await service.UpdatePersonalInfoAsync(cmd);
                response.SuccessResult(res);
            }
            catch (ValidationException e)
            {
                response.Errors = e.ErrorsList;
            }
            catch (CommandExecutionException ex)
            {
                response.Errors.Add(ex.Message);
            }
            return Results.Ok(response);
        });

        group.MapDelete("/{id:guid}", async (Guid id,

        IPersonalInfoService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeletePersonalInfoAsync(id);
                 response.SuccessResult(res);
             }
             catch (ValidationException e)
             {
                 response.Errors = e.ErrorsList;
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
