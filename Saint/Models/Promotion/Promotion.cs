namespace Saint.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RoomType RoomType { get; set; }
    }
}
