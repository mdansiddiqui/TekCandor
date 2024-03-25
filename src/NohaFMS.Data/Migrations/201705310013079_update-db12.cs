/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updatedb12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreLocatorItemLog", "BatchDate", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreLocatorItemLog", "BatchDate");
        }
    }
}
