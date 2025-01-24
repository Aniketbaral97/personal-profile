using Application.DTOs.PersonalInfos;
using Application.Interfaces;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Domain.Enums;

namespace WebApi.EndPoints;


public static class PersonalInfoEndpoints
{
    public static RouteGroupBuilder MapPersonalInfoApi(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/personal-info")
        .WithTags("PersonalInfo");

        group.MapGet("/{id:guid}", async (Guid id,
        IPersonalInfoService repo) =>
        {
            var response = await repo.GetPersonalInfoByIdAsync(id);
            return Results.Ok(response);
        });
        group.MapGet("/", async (int offset, string? name, WorkAvailabilityStatus? status,
        IPersonalInfoService repo) =>
        {
            var response = await repo.GetPersonalInfoList(new PersonalInfoDemoRequestDto()
            {
                Offset = offset,
                Name = name,
                WorkAvailabilityStatus = status ?? 0
            });
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
         }).RequireAuthorization();

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
        }).RequireAuthorization();
        group.MapPut("/is-main", async (
        [FromBody] UpdateMainProfile cmd, IPersonalInfoService service)
        =>
        {
            var response = new ResultModel<int>();
            try
            {
                var res = await service.UpdateIsMain(cmd);
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
        }).RequireAuthorization();
        group.MapGet("/is-main", async (IPersonalInfoService service)
        =>
        {
            var res = await service.GetMainProfile();
            return Results.Ok(res);
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

         }).RequireAuthorization();

        return group;

    }
}
