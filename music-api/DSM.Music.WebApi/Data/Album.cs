namespace DSM.Music.WebApi.Data;

public class Album
{
    public int Id { get; set; }
    public string LookupId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int YearReleased { get; set; }
    public string SalesId { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public int ArtistId { get; set; }
    public Artist Artist { get; set; } = null!;
}