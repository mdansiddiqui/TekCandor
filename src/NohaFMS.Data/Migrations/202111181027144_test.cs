namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.ActivityLog", "Description", c => c.String());
            AlterColumn("dbo.ChequeDepositInformation", "CityCode", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "Export", c => c.Boolean());
            AlterColumn("dbo.ChequeDepositInformation", "Callback", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChequeDepositInformation", "Callback", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ChequeDepositInformation", "Export", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ChequeDepositInformation", "CityCode", c => c.String(maxLength: 2, unicode: false));
            //DropColumn("dbo.ActivityLog", "Description");
        }
    }
}
