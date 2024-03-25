namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_CallbackBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChequeDepositInformation", "Callback", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChequeDepositInformation", "Callback", c => c.Boolean(nullable: false));
        }
    }
}
