namespace vote_with_your_wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCauseTarget2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CauseModels", newName: "Causes");
            RenameTable(name: "dbo.ApplicationUserCauseModels", newName: "ApplicationUserCauses");
            RenameColumn(table: "dbo.ApplicationUserCauses", name: "CauseModel_Id", newName: "Cause_Id");
            RenameIndex(table: "dbo.ApplicationUserCauses", name: "IX_CauseModel_Id", newName: "IX_Cause_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ApplicationUserCauses", name: "IX_Cause_Id", newName: "IX_CauseModel_Id");
            RenameColumn(table: "dbo.ApplicationUserCauses", name: "Cause_Id", newName: "CauseModel_Id");
            RenameTable(name: "dbo.ApplicationUserCauses", newName: "ApplicationUserCauseModels");
            RenameTable(name: "dbo.Causes", newName: "CauseModels");
        }
    }
}
