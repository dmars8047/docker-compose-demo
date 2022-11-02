namespace DSM.Music.WebApi.Contracts;

public class MusicalArtist
{
    public MusicalArtist(string id, string name, string genre, Album[] albums)
    {
        ID = id;
        Name = name;
        Genre = genre;
        Albums = albums;
    }
    
    public string ID { get; }
    public string Name { get; }
    public string Genre { get; }
    public Album[] Albums { get; }
}