namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHubCodeChequeDeposit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "HubCode", c => c.String(maxLength: 4, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChequeDepositInformation", "HubCode");
        }
    }
}
