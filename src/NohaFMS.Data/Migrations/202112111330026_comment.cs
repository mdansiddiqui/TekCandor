namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ActivityLog", "Comment", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ActivityLog", "Comment", c => c.String(maxLength: 1024));
        }
    }
}
