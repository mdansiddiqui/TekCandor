/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateusertimezone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "TimeZoneId", c => c.String(maxLength: 128, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "TimeZoneId");
        }
    }
}
