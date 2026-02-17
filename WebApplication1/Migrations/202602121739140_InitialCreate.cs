namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        MedicineName = c.String(),
                        Stock = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Available = c.Boolean(nullable: false),
                        PharmacyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.UserMedicines",
                c => new
                    {
                        UserMedicineId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MedicineName = c.String(),
                        Dosage = c.String(),
                        ReminderTime = c.Time(nullable: false, precision: 7),
                        TotalQuantity = c.Int(nullable: false),
                        RemainingQuantity = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.UserMedicineId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UserMedicines");
            DropTable("dbo.Medicines");
        }
    }
}
