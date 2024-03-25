namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class isDeletedMyReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyReport", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyReport", "IsDeleted");
        }
    }
}
