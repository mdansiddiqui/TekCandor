namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChequeDepoittblforaddReturnReasonColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "Returnreasone", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChequeDepositInformation", "Returnreasone");
        }
    }
}
