using DSM.Music.WebApi.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSM.Music.WebApi.Controllers;

[ApiController]
[Route("music")]
public class ArtistController : ControllerBase
{
    private readonly DSM.Music.WebApi.Data.MusicDbContext _dbContext;
    private readonly ILogger<ArtistController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public ArtistController(
        ILogger<ArtistController> logger,
        DSM.Music.WebApi.Data.MusicDbContext dbContext,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _dbContext = dbContext;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    [Route("artists")]
    public async Task<IActionResult> All()
    {
        _logger.LogInformation("Request recieved for artists at {time}", DateTime.Now);

        var result = new List<ArtistSummary>();

        var dbRecords = await _dbContext.Artists.ToListAsync();

        foreach (var record in dbRecords)
        {
            result.Add(new ArtistSummary(record.LookupId, record.Name, record.Genre, record.ThumbnailUrl));
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("artists/{artistId}/albums")]
    public async Task<IActionResult> ArtistAlbums([FromRoute] string artistId)
    {
        _logger.LogInformation("Request recieved for artist ('{artistId}') albums at {time}", artistId, DateTime.Now);

        if (!await _dbContext.Artists.AnyAsync(x => x.LookupId == artistId))
        {
            return NotFound($"Artist with ID: {artistId} does not exit.");
        }

        var artistRecord = await _dbContext.Artists.Include(x => x.Albums).SingleAsync(x => x.LookupId == artistId);

        var result = new List<Album>();

        using var httpClient = _httpClientFactory.CreateClient("SalesData");

        foreach(var albumRecord in artistRecord.Albums)
        {
            var salesResponse  = await httpClient.GetAsync($"sales/stats/{albumRecord.SalesId}");

            if(!salesResponse.IsSuccessStatusCode)
            {
                throw new Exception("Error: Could not successfully call the Sales Data Api.");
            }

            SalesData? salesData = await salesResponse.Content.ReadFromJsonAsync<SalesData>();

            if(salesData == null)
            {
                throw new Exception("Error: An error occurred parsing the response from the Sales Data Api.");
            }

            result.Add(new Album(albumRecord.LookupId, albumRecord.Name, albumRecord.YearReleased, salesData));
        }

        return Ok(result);
    }
}
