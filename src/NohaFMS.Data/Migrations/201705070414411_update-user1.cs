/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateuser1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Number", c => c.String(maxLength: 128, storeType: "nvarchar"));
            AddColumn("dbo.User", "AssignmentId", c => c.Long());
            CreateIndex("dbo.User", "AssignmentId");
            AddForeignKey("dbo.User", "AssignmentId", "dbo.Assignment", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "AssignmentId", "dbo.Assignment");
            DropIndex("dbo.User", new[] { "AssignmentId" });
            DropColumn("dbo.User", "AssignmentId");
            DropColumn("dbo.User", "Number");
        }
    }
}
