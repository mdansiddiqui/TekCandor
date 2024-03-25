namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumcallbachsend_in_chequedeposit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "Callbacksend", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChequeDepositInformation", "Callbacksend");
        }
    }
}
