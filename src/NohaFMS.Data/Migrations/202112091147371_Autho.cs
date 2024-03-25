namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Autho : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "Auth", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
        }
    }
}
