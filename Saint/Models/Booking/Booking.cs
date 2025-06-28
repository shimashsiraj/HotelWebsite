namespace Saint.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

        // Deposit-related fields
        public decimal DepositAmount { get; set; }
        public bool IsDepositReturned { get; set; }
        public DateTime? DepositReturnedDate { get; set; }

        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public Payment Payment { get; set; }
    }
}
