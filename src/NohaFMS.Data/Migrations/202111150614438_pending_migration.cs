namespace NohaFMS.Data.Migrations
{
   
    using System.Data.Entity.Migrations;
    
    public partial class pending_migration : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.ChequeDepositInformation", "ChequeDepositInformation_Id", c => c.Long());
            //CreateIndex("dbo.ChequeDepositInformation", "ChequeDepositInformation_Id");
            //AddForeignKey("dbo.ChequeDepositInformation", "ChequeDepositInformation_Id", "dbo.ChequeDepositInformation", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.ChequeDepositInformation", "ChequeDepositInformation_Id", "dbo.ChequeDepositInformation");
            //DropIndex("dbo.ChequeDepositInformation", new[] { "ChequeDepositInformation_Id" });
            //DropColumn("dbo.ChequeDepositInformation", "ChequeDepositInformation_Id");
        }
    }
}
