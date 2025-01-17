using Application.Interfaces;
using Application.Exceptions;
using Application.DTOs.Experiences;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.EndPoints;

public static class ExperienceEndpoints
{
    public static RouteGroupBuilder MapExperienceApi(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/experience")
        .WithTags("Experience")
         ;

        group.MapGet("/{id:guid}", async (Guid id,
        IExperienceService repo) =>
        {
            var response = await repo.GetExperiencesByInfoIdAsync(id);
            return Results.Ok(response);
        });
        
        group.MapPost("/", async (CreateManyExperienceDto command,
        IExperienceService service)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await service.AddExperienceAsync(command);
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
        [FromBody] UpdateExperienceDto cmd, IExperienceService service)
        =>
        {
            var response = new ResultModel<int>();
            try
            {
                var res = await service.UpdateExperienceAsync(cmd);
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

        IExperienceService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteExperienceAsync(id);
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
        group.MapDelete("/info-id/{id:guid}", async (Guid id,

        IExperienceService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteExperienceByInfoIdAsync(id);
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
