using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "Medicine name is required")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$",
            ErrorMessage = "Medicine name can only contain letters and numbers")]
        public string MedicineName { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$",
            ErrorMessage = "Company name can only contain letters and numbers")]
        public string MedicineCompany { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(1, 10000, ErrorMessage = "Stock must be greater than or equal to 1")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public bool Available { get; set; }

        [Required(ErrorMessage = "Pharmacy ID is required")]
        public int PharmacyId { get; set; }
    }
}