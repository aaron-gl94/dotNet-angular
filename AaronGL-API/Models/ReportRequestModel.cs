namespace AaronGLAPI.Models;
public class ReportRequest
{
    public required List<int> Ids { get; set; }
    public required string Date { get; set; }
}