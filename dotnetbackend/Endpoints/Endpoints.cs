using FluentValidation;
using dotnetbackend.Exceptions;
using dotnetbackend.RequestModels;
using dotnetbackend.Services;
using dotnetbackend.Validators;

namespace dotnetbackend.Endpoints;

public static class Endpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/characters/{id:int}",GetCharacter);
        app.MapPost("/characters/{id:int}/backpackslots", PostBackPackSlot);
    }

    public static async Task<IResult> GetCharacter(IService service, int id)
    {
        try
        {
            var result = await service.GetCharacterInfoAsync(id);
            return Results.Ok(result);
        }
        catch (NotFoundException e)
        {
            return Results.NotFound(e.Message);
        }
    }

    public static async Task<IResult> PostBackPackSlot(IService service,int id,IValidator<PostSlotRequestModel> validator,PostSlotRequestModel request)
    {
        var validation = await validator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            return Results.ValidationProblem(validation.ToDictionary());
        }
        try
        {
            var result = await service.AddToInventory(id, request.itemIds);
            return Results.Ok(result); //wysyłamy konkretny model. Mogłoby być created gdybysmy chcieli wskazac jedną loakcję
        }
        catch (NotFoundException e)
        {
            return Results.NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return Results.BadRequest(e.Message);
        }
    }

}