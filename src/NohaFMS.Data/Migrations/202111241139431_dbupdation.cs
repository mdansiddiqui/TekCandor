namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class dbupdation : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.ReturnReason", "AlphaReturnCodes", c => c.String(maxLength: 8000, unicode: false));
            //AddColumn("dbo.ReturnReason", "NumericReturnCodes", c => c.Int(nullable: false));
            //AddColumn("dbo.ReturnReason", "DescriptionWithReturnCodes", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.ReturnReason", "DescriptionWithReturnCodes");
            //DropColumn("dbo.ReturnReason", "NumericReturnCodes");
           // DropColumn("dbo.ReturnReason", "AlphaReturnCodes");
        }
    }
}
