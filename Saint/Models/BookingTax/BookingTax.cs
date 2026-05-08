namespace Saint.Models
{
    public class BookingTax
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string TaxName { get; set; }   // "HST", "City Tax"
        public decimal TaxRate { get; set; }  // 13
        public decimal TaxAmount { get; set; } // e.g. $15.60

        public Booking Booking { get; set; }
    }
}
