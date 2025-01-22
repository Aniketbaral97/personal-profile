using Application.Interfaces;
using Application.Exceptions;
using Application.DTOs.References;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.EndPoints;

public static class ReferenceEndpoints
{
    public static RouteGroupBuilder MapReferenceApi(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/reference")
        .WithTags("Reference")
         ;

        group.MapGet("/{id:guid}", async (Guid id,
        IReferenceService repo) =>
        {
            var response = await repo.GetReferencesByInfoIdAsync(id);
            return Results.Ok(response);
        });
        
        group.MapPost("/", async (CreateManyReferenceDto command,
        IReferenceService service)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await service.AddReferenceAsync(command);
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
        [FromBody] UpdateReferenceDto cmd, IReferenceService service)
        =>
        {
            var response = new ResultModel<int>();
            try
            {
                var res = await service.UpdateReferenceAsync(cmd);
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

        IReferenceService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteReferenceAsync(id);
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

        IReferenceService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteReferenceByInfoIdAsync(id);
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
