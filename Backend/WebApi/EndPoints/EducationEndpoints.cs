using Application.Interfaces;
using Application.Exceptions;
using Application.DTOs.Educations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.EndPoints;

public static class EducationEndpoints
{
    public static RouteGroupBuilder MapEducationtApi(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/education")
        .WithTags("Education");

        group.MapGet("/{id:guid}", async (Guid id,
        IEducationService repo) =>
        {
            var response = await repo.GetEducationsByInfoIdAsync(id);
            return Results.Ok(response);
        });
        
        group.MapPost("/", async (CreateManyEducationDto command,
        IEducationService service)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await service.AddEducationAsync(command);
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
        [FromBody] UpdateEducationDto cmd, IEducationService service)
        =>
        {
            var response = new ResultModel<int>();
            try
            {
                var res = await service.UpdateEducationAsync(cmd);
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

        group.MapDelete("/{id:guid}", async (Guid id,

        IEducationService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteEducationAsync(id);
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

        group.MapDelete("/info-id/{id:guid}", async (Guid id,

        IEducationService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteEducationByInfoIdAsync(id);
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
