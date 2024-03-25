namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pednchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "InstrumentNo", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
