using System.ComponentModel.DataAnnotations.Schema;

namespace Saint.Models
{
    public class RoomTypeCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }


        [NotMapped]
        public List<IFormFile> RoomImages { get; set; }

    }
}
