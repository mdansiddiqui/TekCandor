/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateassignment1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "AvailableActions", c => c.String(maxLength: 1024, storeType: "nvarchar"));
            AlterColumn("dbo.Assignment", "Comment", c => c.String(maxLength: 1024, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Assignment", "Comment", c => c.String(unicode: false));
            DropColumn("dbo.Assignment", "AvailableActions");
        }
    }
}
