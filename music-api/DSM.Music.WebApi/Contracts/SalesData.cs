namespace DSM.Music.WebApi.Contracts;

public class SalesData
{
    public SalesData(int unitsSold, int totalRevenue)
    {
        UnitsSold = unitsSold;
        TotalRevenue = totalRevenue;
    }

    public int UnitsSold { get; }
    public int TotalRevenue { get; }
}