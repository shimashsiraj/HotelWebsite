namespace Saint.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public bool IsPreAuthorized { get; set; }

        public Booking Booking { get; set; }
    }
}
