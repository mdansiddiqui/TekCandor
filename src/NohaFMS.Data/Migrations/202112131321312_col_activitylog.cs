namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class col_activitylog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ActivityLog", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ActivityLog", "Comment", c => c.String());
        }
    }
}
