namespace DSM.SalesData.WebApi.Data;

public class SalesData
{
    public int Id { get; set; }
    public string LookupId { get; set; } = string.Empty;
    public int UnitsSold { get; set; }
    public int TotalRevenue { get; set; }
}