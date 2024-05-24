namespace AaronGLAPI.Models
{
    public class SalesData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Sales { get; set; }
        public decimal Expenses { get; set; }
        public DateTime Date { get; set; }
    }
}