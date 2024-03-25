namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class nothing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChequeDepositInformation", "Export", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChequeDepositInformation", "Export", c => c.Boolean(nullable: false));
        }
    }
}
