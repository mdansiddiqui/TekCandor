
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class conf : DbMigration
    {
        public override void Up()
        {
          //  AddColumn("dbo.Cycle", "Description", c => c.String());
           // AddColumn("dbo.ChequeDepositInformation", "Remarks", c => c.String(maxLength: 8000, unicode: false));
            // DropColumn("dbo.Cycle", "Days");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cycle", "Days", c => c.Int(nullable: false));
            DropColumn("dbo.ChequeDepositInformation", "Remarks");
            DropColumn("dbo.Cycle", "Description");
        }
    }
}
