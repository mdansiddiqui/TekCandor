namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class alter_callBack : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChequeDepositInformation", "CallBack", c => c.Boolean());
        }

        public override void Down()
        {
            AlterColumn("dbo.ChequeDepositInformation", "CallBack", c => c.Boolean(nullable: false));
        }
    }
}
