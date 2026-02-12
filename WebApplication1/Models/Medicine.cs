using System;
namespace WebApplication1.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }

        public string MedicineName { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; }

        public int PharmacyId { get; set; }
    }
}