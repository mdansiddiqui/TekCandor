namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastCycle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cycle", "Code", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cycle", "Code", c => c.String(maxLength: 10));
        }
    }
}
