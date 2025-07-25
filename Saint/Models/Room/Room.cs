﻿namespace Saint.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public string Status { get; set; }

        public RoomType RoomType { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
