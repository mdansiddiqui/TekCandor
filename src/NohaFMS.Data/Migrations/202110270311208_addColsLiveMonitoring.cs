namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class addColsLiveMonitoring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LiveMonitoring", "IsNew", c => c.Boolean(nullable:false));
            AddColumn("dbo.LiveMonitoring", "IsDeleted", c => c.Boolean(nullable: false));
            
        }

        public override void Down()
        {
            
            DropColumn("dbo.LiveMonitoring", "IsNew");
            DropColumn("dbo.LiveMonitoring", "IsDeleted");
        }
    }
}
