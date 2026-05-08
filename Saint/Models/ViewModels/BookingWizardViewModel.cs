using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Saint.Models.ViewModels
{
    public class BookingWizardViewModel
    {
        // Step 1 - Customer
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Area Code")]
        public string AreaCode { get; set; }

        public string CountryCode { get; set; }

        [Required]
        public string Phone { get; set; }

        // Step 2 - Stay Details
        public string RoomTypeName { get; set; }
        public int RoomTypeId { get; set; }
        public List<string> RoomImages { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        public int Nights { get; set; }

        public int Occupancy { get; set; }
        // Step 3 - Policies
        public List<HotelPolicy> Policies { get; set; } = new List<HotelPolicy>();
        [Required(ErrorMessage = "You must agree to the terms and conditions.")]
        public bool AgreedToTerms { get; set; }

        // Step 4 - Payment
        public decimal RoomCost { get; set; }
        public decimal Tax { get; set; }

        public List<TaxDetailViewModel> AppliedTaxes { get; set; } = new List<TaxDetailViewModel>();
        public decimal TotalCost { get; set; }


    }

    public class TaxDetailViewModel
    {
        public string TaxName { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
    }
}

