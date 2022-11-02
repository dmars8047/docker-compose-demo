namespace DSM.Music.WebApi.Contracts;

public class Album
{
    public Album(string id, string name, int yearReleased, SalesData salesData)
    {
        ID = id;
        Name = name;
        YearReleased = yearReleased;
        SalesData = salesData;
    }

    public string ID { get; }
    public string Name { get; }
    public int YearReleased { get; }
    public SalesData SalesData { get; }
}