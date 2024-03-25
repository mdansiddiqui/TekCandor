namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Hubid", c => c.Long(nullable:true));
            AddColumn("dbo.User", "BranchId", c => c.Long(nullable:true));
            AddColumn("dbo.User", "UperLimie", c => c.String(nullable:true));
            AddColumn("dbo.User", "BottonLimit", c => c.String(nullable:true));
            AddColumn("dbo.User", "IsSupervisor", c => c.Boolean(nullable:true));

        }

        public override void Down()
        {
            DropColumn("dbo.User", "IsSupervisor");
            DropColumn("dbo.User", "UperLimie");
            DropColumn("dbo.User", "BottonLimit");
            DropColumn("dbo.User", "BranchId");
            DropColumn("dbo.User", "Hubid");
        }
    }
}
