namespace vote_with_your_wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCauseTarget : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Causes", newName: "CauseModels");
            RenameTable(name: "dbo.ApplicationUserCauses", newName: "ApplicationUserCauseModels");
            RenameColumn(table: "dbo.ApplicationUserCauseModels", name: "Cause_Id", newName: "CauseModel_Id");
            RenameIndex(table: "dbo.ApplicationUserCauseModels", name: "IX_Cause_Id", newName: "IX_CauseModel_Id");
            AddColumn("dbo.CauseModels", "CauseTarget", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CauseModels", "CauseTarget");
            RenameIndex(table: "dbo.ApplicationUserCauseModels", name: "IX_CauseModel_Id", newName: "IX_Cause_Id");
            RenameColumn(table: "dbo.ApplicationUserCauseModels", name: "CauseModel_Id", newName: "Cause_Id");
            RenameTable(name: "dbo.ApplicationUserCauseModels", newName: "ApplicationUserCauses");
            RenameTable(name: "dbo.CauseModels", newName: "Causes");
        }
    }
}
