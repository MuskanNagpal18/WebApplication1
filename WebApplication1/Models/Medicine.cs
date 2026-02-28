using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "Medicine name is required")]
        [StringLength(100)]
        public string MedicineName { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        public string MedicineCompany { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(0, 10000, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public bool Available { get; set; }

        public int PharmacyId { get; set; }
    }
}