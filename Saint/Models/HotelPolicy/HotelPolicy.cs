using System.ComponentModel;

namespace Saint.Models
{
    public class HotelPolicy
    {
        public int Id { get; set; }
        public string Title { get; set; }        // e.g., "Check-in Policy", "Cancellation Policy"
        public string Description { get; set; }  // Full policy text
        [DisplayName("Updated On")]
        public DateTime LastUpdated { get; set; }
    }
}
