namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class op : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.City", "City_Id", "dbo.City");
            //DropIndex("dbo.City", new[] { "City_Id" });
            //DropColumn("dbo.City", "City_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.City", "City_Id", c => c.Long());
            //CreateIndex("dbo.City", "City_Id");
            //AddForeignKey("dbo.City", "City_Id", "dbo.City", "Id");
        }
    }
}
