namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserMedicines");
        }
    }
}
