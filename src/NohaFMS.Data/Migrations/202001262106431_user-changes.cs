namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "AssignmentId", "dbo.Assignment");
            AddColumn("dbo.User", "OrganizationId", c => c.Long(nullable: false));
            AlterColumn("dbo.User", "Number", c => c.String());
            AlterColumn("dbo.User", "Description", c => c.String());
            CreateIndex("dbo.User", "OrganizationId");
            AddForeignKey("dbo.User", "OrganizationId", "dbo.Organization", "Id");
            AddForeignKey("dbo.User", "AssignmentId", "dbo.Assignment", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.User", "OrganizationId", "dbo.Organization");
            DropIndex("dbo.User", new[] { "OrganizationId" });
            AlterColumn("dbo.User", "Description", c => c.String(maxLength: 512));
            AlterColumn("dbo.User", "Number", c => c.String(maxLength: 64));
            DropColumn("dbo.User", "OrganizationId");
            AddForeignKey("dbo.User", "AssignmentId", "dbo.Assignment", "Id", cascadeDelete: true);
        }
    }
}
