namespace Saint.Models
{
    public class Tax
    {
        public int Id { get; set; }
        public decimal TaxRate { get; set; } // e.g., 13 for 13%
        public DateTime EffectiveFrom { get; set; }
    }
}
