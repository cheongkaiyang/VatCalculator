namespace TaxCalculator.Models
{
    public class VatComponent
    {
        public decimal VatRate { get; set; }
        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VatAmount { get; set; }
    }
}
