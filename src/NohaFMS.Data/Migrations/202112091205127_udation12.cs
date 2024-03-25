namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class udation12 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.ChequeDepositInformation", "Auth", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChequeDepositInformation", "Auth");
        }
    }
}
