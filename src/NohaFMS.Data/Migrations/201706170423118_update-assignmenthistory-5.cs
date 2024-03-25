/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateassignmenthistory5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssignmentHistory", "AssignmentAmount", c => c.Decimal(precision: 19, scale: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssignmentHistory", "AssignmentAmount", c => c.Decimal(nullable: false, precision: 19, scale: 4));
        }
    }
}
