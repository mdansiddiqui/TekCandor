namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_columnchequedate_callBack : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChequeDepositInformation", "chequeDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChequeDepositInformation", "chequeDate", c => c.DateTime(nullable: false));
        }
    }
}
