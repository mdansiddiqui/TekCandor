namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_errorFieldinChequeDeposit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "Error", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChequeDepositInformation", "Error");
        }
    }
}
