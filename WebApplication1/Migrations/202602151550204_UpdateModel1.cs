namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Role", c => c.String(nullable: false));
            DropTable("dbo.UserMedicines");
        }
        
        public override void Down()
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
            
            AlterColumn("dbo.Users", "Role", c => c.String());
        }
    }
}
