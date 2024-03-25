namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChequeDepositinfoTblForImgae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "imgF", c => c.Binary());
            AddColumn("dbo.ChequeDepositInformation", "imgR", c => c.Binary());
            AddColumn("dbo.ChequeDepositInformation", "imgU", c => c.Binary());
            AddColumn("dbo.ChequeDepositInformation", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChequeDepositInformation", "status");
            DropColumn("dbo.ChequeDepositInformation", "imgU");
            DropColumn("dbo.ChequeDepositInformation", "imgR");
            DropColumn("dbo.ChequeDepositInformation", "imgF");
        }
    }
}
