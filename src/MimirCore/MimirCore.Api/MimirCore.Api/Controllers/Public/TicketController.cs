using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Api.Models.Ticket;
using MimirCore.Application.CQRS.Normal.Commands.Ticket;
using MimirCore.Application.CQRS.Normal.Queries.Ticket;

namespace MimirCore.Api.Controllers.Public;

[Authorize]
[Route("api/tickets")]
public class TicketController : BaseApiController
{
    [HttpGet("my-tickets")]
    public async Task<ActionResult<TicketPaginatedListResponse>> GetMyTickets(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? status = null,
        [FromQuery] string? priority = null)
    {
        var userId = GetCurrentUserId();
        var query = new GetMyTicketsQuery
        {
            UserId = userId,
            PageNumber = pageNumber,
            PageSize = pageSize,
            Status = status,
            Priority = priority
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketResponse>> GetTicketById(int id)
    {
        var userId = GetCurrentUserId();
        var query = new GetTicketByIdQuery(id, userId);
        var result = await Mediator.Send(query);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<ActionResult<TicketResponse>> CreateTicket([FromBody] CreateTicketRequest request)
    {
        var userId = GetCurrentUserId();
        var command = new CreateTicketCommand
        {
            Title = request.Title,
            Description = request.Description,
            CategoryId = request.CategoryId,
            Priority = request.Priority,
            CreatedById = userId
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TicketResponse>> UpdateTicket(int id, [FromBody] UpdateTicketRequest request)
    {
        var userId = GetCurrentUserId();
        var command = new UpdateTicketCommand
        {
            Id = id,
            Title = request.Title,
            Description = request.Description,
            CategoryId = request.CategoryId,
            Priority = request.Priority,
            UserId = userId
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }
}