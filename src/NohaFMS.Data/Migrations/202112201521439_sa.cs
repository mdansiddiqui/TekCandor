namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa : DbMigration
    {
        public override void Up()
        {
            
            //AddColumn("dbo.ChequeDepositInformation", "Auth", c => c.Boolean(nullable: false));
            //AddColumn("dbo.ChequeDepositInformation", "NiftBranchCode", c => c.String());
            //AddColumn("dbo.ChequeDepositInformation", "InstrumentNo", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.ChequeDepositInformation", "InstrumentNo");
            //DropColumn("dbo.ChequeDepositInformation", "NiftBranchCode");
            //DropColumn("dbo.ChequeDepositInformation", "Auth");
            
        }
    }
}
