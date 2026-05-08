using System.ComponentModel.DataAnnotations;

namespace Saint.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string CountryCode { get; set; }

        [Phone]
        public int Phone { get; set; }


        //public ICollection<Booking> Bookings { get; set; }
        //public ICollection<Review> Reviews { get; set; }
    }
}
