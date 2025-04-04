using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Data.Commands;
using Models.Data.Queries;

namespace TestFBT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController(IMediator mediator): ControllerBase
{
    [HttpPost("save")]
    public async Task<IActionResult> SaveData([FromBody] List<DataItem> inputData)
    {
        var command = new DeleteAndSaveCommand
        {
            DataItems = inputData
        };
        var result = await mediator.Send(command);
        if (result)
        {
            return Ok();
        }
        else
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetData([FromQuery] int? code = null)
    {
        var query = new GetDataItemQuery
        {
            CodeFilter = code
        };
        var result = await mediator.Send(query);

        return Ok(result);
    }
}
