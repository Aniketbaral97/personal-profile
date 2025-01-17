using Application.Interfaces;
using Application.Exceptions;
using Application.DTOs.Skills;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.EndPoints;

public static class SkillEndpoints
{
    public static RouteGroupBuilder MapSkillApi(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/skill")
        .WithTags("Skill")
         ;

        group.MapGet("/{id:guid}", async (Guid id,
        ISkillService repo) =>
        {
            var response = await repo.GetSkillsByInfoIdAsync(id);
            return Results.Ok(response);
        });
        
        group.MapPost("/", async (CreateManySkillDto command,
        ISkillService service)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await service.AddSkillAsync(command);
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
        [FromBody] UpdateSkillDto cmd, ISkillService service)
        =>
        {
            var response = new ResultModel<int>();
            try
            {
                var res = await service.UpdateSkillAsync(cmd);
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

        ISkillService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteSkillAsync(id);
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

        ISkillService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteSkillByInfoIdAsync(id);
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
