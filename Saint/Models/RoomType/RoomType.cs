namespace Saint.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }


        public ICollection<RoomImage> RoomImages { get; set; }

        public ICollection<Room> Rooms { get; set; }
        //public ICollection<Promotion> Promotions { get; set; }
    }
}
