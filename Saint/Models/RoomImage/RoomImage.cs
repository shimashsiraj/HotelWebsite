namespace Saint.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public string ImageUrl { get; set; }     // Store relative path or blob URL
        public string Caption { get; set; }      // Optional (e.g., "Bathroom view")

        public RoomType RoomType { get; set; }
    }
}
