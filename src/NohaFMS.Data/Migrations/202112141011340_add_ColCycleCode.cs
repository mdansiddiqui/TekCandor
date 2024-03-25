namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class add_ColCycleCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cycle", "Code", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cycle", "Code");
        }
    }
}
