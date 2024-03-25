/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updatefeature1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feature", "EntityType", c => c.String(maxLength: 64, storeType: "nvarchar"));
            AddColumn("dbo.Feature", "WorkflowEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feature", "WorkflowEnabled");
            DropColumn("dbo.Feature", "EntityType");
        }
    }
}
