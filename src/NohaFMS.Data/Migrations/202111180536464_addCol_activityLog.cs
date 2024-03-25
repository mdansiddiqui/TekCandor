namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class addCol_activityLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityLog", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActivityLog", "Description");
        }
    }
}
