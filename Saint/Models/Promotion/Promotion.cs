using System.ComponentModel;

namespace Saint.Models
{
    public class Promotion
    {
        public int Id { get; set; }

        [DisplayName("Promotion Name")]
        public string PromotionName { get; set; }

        [DisplayName("Room Type")]
        public int RoomTypeId { get; set; }

        [DisplayName("Discount %")]
        public decimal DiscountPercent { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public RoomType RoomType { get; set; }
    }
}
