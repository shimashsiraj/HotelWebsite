using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Saint.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string BookingReference { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

        // Deposit-related fields
        public decimal? DepositAmount { get; set; }
        public string? DepositMethod { get; set; }
        public bool? IsDepositReturned { get; set; }
        public DateTime? DepositReturnedDate { get; set; }

        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public Payment Payment { get; set; }
        public ICollection<BookingTax> BookingTaxes { get; set; } // ✅ tax breakdown

    }
}
