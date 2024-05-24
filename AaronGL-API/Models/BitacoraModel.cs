namespace AaronGLAPI.Models
{
    public class Bitacora
    {
        public int IdLog { get; set; }
        public DateTime DateLog { get; set; }
        public SalesData? SaleLog { get; set; }
    }
}