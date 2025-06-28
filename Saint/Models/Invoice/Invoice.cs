namespace Saint.Models.Invoice
{
    public class Invoice
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public Booking Booking { get; set; }
    }
}
