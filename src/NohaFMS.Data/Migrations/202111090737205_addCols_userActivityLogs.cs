namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class addCols_userActivityLogs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserActivityLogs", "UrlAccessed", c => c.String(maxLength:300, unicode: false));
        }

        public override void Down()
        {
            AddColumn("dbo.UserActivityLogs", "UrlAccessed", c => c.String(maxLength: 200, unicode: false));
        }
    }
}
