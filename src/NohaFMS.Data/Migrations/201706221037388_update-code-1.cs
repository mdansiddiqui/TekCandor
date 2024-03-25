/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updatecode1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Code", "Description", c => c.String(maxLength: 512, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Code", "Description");
        }
    }
}
