namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupSecurity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecurityGroup", "UpperLimit", c => c.Int(nullable: false));
            AddColumn("dbo.SecurityGroup", "LowerLimit", c => c.Int(nullable: false));
            AddColumn("dbo.SecurityGroup", "LimitGroup", c => c.String(maxLength: 10));
        }

        public override void Down()
        {
            DropColumn("dbo.SecurityGroup", "UpperLimit");
            DropColumn("dbo.SecurityGroup", "LowerLimit");
            DropColumn("dbo.SecurityGroup", "LimitGroup");

        }
    }
}
