namespace DSM.Music.WebApi.Contracts;

public class ArtistSummary
{
    public ArtistSummary(string id, string name, string genre, string thumbnailUrl)
    {
        Name = name;
        Genre = genre;
        ID = id;
        ThumbnailUrl = thumbnailUrl;
    }

    public string ID { get; }
    public string Name { get; }
    public string Genre { get; }
    public string ThumbnailUrl { get; }
}