/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateissue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issue", "IssueTo", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issue", "IssueTo");
        }
    }
}
