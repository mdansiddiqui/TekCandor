namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReturnReason", "Status", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReturnReason", "Status");
        }
    }
}
