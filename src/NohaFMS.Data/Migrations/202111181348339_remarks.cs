namespace NohaFMS.Data.Migrations
{
    //using System;
    using System.Data.Entity.Migrations;
    
    public partial class remarks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "Remarks", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChequeDepositInformation", "Remarks");
        }
    }
}
