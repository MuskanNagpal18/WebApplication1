using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserMedicine
    {
        public int UserMedicineId { get; set; }

        public int UserId { get; set; }

        
        [Required(ErrorMessage = "Medicine name is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$",
        ErrorMessage = "Medicine name can only contain only letters and numbers")]
        public string MedicineName { get; set; }

        [Required(ErrorMessage = "Dosage is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$",
       ErrorMessage = "Dosage can only contain letters and numbers")]
        public string Dosage { get; set; }

        [Required(ErrorMessage = "Reminder time is required")]
        [Display(Name = "Reminder Time")]
        public TimeSpan ReminderTime { get; set; }

        [Required(ErrorMessage = "Total quantity is required")]
        [Range(1, 1000, ErrorMessage = "Quantity must be greater than 0")]
        [Display(Name = "Total Quantity")]
        public int TotalQuantity { get; set; }

        public int RemainingQuantity { get; set; }

        public string Status { get; set; }
    }
}