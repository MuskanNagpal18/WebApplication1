using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserMedicine
    {
        public int UserMedicineId { get; set; }

        // Foreign Key to User
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Medicine Name")]
        public string MedicineName { get; set; }

        [Required]
        public string Dosage { get; set; }

        [Required]
        [Display(Name = "Reminder Time")]
        public TimeSpan ReminderTime { get; set; }

        [Required]
        [Display(Name = "Total Quantity")]
        public int TotalQuantity { get; set; }

        public int RemainingQuantity { get; set; }

        public string Status { get; set; }
    }
}