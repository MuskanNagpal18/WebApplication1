
using System;

namespace WebApplication1.Models
{
    public class UserMedicine
    {
        public int UserMedicineId { get; set; }

        public int UserId { get; set; }

        public string MedicineName { get; set; }

        public string Dosage { get; set; }

        public TimeSpan ReminderTime { get; set; }

        public int TotalQuantity { get; set; }

        public int RemainingQuantity { get; set; }

        public string Status { get; set; }
    }
}