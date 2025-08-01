using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Domain.Entities;
using MimirCore.Application.CQRS.BackOffice.Commands.System;
using MimirCore.Application.CQRS.BackOffice.Queries.System;

namespace MimirCore.Api.Controllers.BackOffice;

[Authorize(Roles = "Admin,BackOffice")]
[Route("api/backoffice/system")]
public class SystemController : BaseApiController
{
    [HttpGet("settings")]
    public async Task<ActionResult<IEnumerable<SystemSetting>>> GetSystemSettings([FromQuery] string? category = null)
    {
        var query = new GetSystemSettingsQuery { Category = category };
        var result = await Mediator.Send(query);
        return HandleResult(result);
    }

    [HttpPut("settings")]
    public async Task<ActionResult> UpdateSystemSetting([FromBody] UpdateSystemSettingRequest request)
    {
        var command = new UpdateSystemSettingCommand
        {
            Key = request.Key,
            Value = request.Value,
            Description = request.Description
        };

        await Mediator.Send(command);
        return Ok();
    }
}

public class UpdateSystemSettingRequest
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}