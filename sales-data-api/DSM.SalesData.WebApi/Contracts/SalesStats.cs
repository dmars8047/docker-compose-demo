namespace DSM.SalesData.WebApi.Contracts;

public class SalesStats
{
    public SalesStats(string id, int unitsSold, int totalRevenue)
    {
        Id = id;
        UnitsSold = unitsSold;
        TotalRevenue = totalRevenue;
    }

    public string Id { get; }
    public int UnitsSold { get; }
    public int TotalRevenue { get; }
}