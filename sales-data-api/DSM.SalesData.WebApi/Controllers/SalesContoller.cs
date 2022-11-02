using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSM.SalesData.WebApi.Contracts;

namespace DSM.SalesData.WebApi.Controllers;

[ApiController]
[Route("sales")]
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;
    private readonly DSM.SalesData.WebApi.Data.SalesDbContext _dbContext;

    public SalesController(ILogger<SalesController> logger, Data.SalesDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet]
    [Route("stats/{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        _logger.LogInformation("Request recieved to get sales stats for {id} at {time}", id, DateTime.Now);

        if (!await _dbContext.SalesData.AnyAsync(x => x.LookupId == id))
        {
            return NotFound($"Sales data entry with ID: {id} does not exit.");
        }

        var record = await _dbContext.SalesData.SingleAsync(y => y.LookupId == id);

        var result = new SalesStats(record.LookupId, record.UnitsSold, record.TotalRevenue);

        return Ok(result);
    }
}