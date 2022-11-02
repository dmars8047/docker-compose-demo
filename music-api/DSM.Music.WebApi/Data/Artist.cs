namespace DSM.Music.WebApi.Data;

public class Artist
{
    public int Id { get; set; }
    public string LookupId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public List<Album> Albums { get; set; } = new List<Album>();
}