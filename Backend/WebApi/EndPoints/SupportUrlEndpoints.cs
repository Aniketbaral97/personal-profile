using Application.Interfaces;
using Application.Exceptions;
using Application.DTOs.SupportUrls;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.EndPoints;

public static class SupportUrlEndpoints
{
    public static RouteGroupBuilder MapSupportUrlApi(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/support-url")
        .WithTags("SupportUrl")
        .RequireAuthorization();

        group.MapGet("/{id:guid}", async (Guid id,
        ISupportUrlService repo) =>
        {
            var response = await repo.GetSupportUrlsByInfoIdAsync(id);
            return Results.Ok(response);
        });
        
        group.MapPost("/", async (CreateManySupportUrlDto command,
        ISupportUrlService service)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await service.AddSupportUrlAsync(command);
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
        [FromBody] UpdateSupportUrlDto cmd, ISupportUrlService service)
        =>
        {
            var response = new ResultModel<int>();
            try
            {
                var res = await service.UpdateSupportUrlAsync(cmd);
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

        ISupportUrlService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteSupportUrlAsync(id);
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

        ISupportUrlService repo)
         =>
         {
             var response = new ResultModel<int>();
             try
             {
                 var res = await repo.DeleteSupportUrlByInfoIdAsync(id);
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
