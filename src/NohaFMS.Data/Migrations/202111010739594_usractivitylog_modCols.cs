namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usractivitylog_modCols : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserActivityLogs", "UserId", c => c.String());
            //AlterColumn("dbo.UserActivityLogs", "CreatedLogTime", c => c.DateTime());

        }

        public override void Down()
        {
            AlterColumn("dbo.UserActivityLogs", "UserId", c => c.String());
            //AlterColumn("dbo.UserActivityLogs", "CreatedLogTime", c => c.DateTime());
        }
    }
}
