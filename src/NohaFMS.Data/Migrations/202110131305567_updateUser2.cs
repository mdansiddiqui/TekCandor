namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "BranchIds", c => c.String(maxLength: 128));
            AddColumn("dbo.User", "Hubids", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Hubids");
            DropColumn("dbo.User", "BranchIds");
        }
    }
}
