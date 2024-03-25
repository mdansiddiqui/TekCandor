namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class p : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.City", "City_Id", c => c.Long());
            //CreateIndex("dbo.City", "City_Id");
            //AddForeignKey("dbo.City", "City_Id", "dbo.City", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.City", "City_Id", "dbo.City");
            //DropIndex("dbo.City", new[] { "City_Id" });
            //DropColumn("dbo.City", "City_Id");
        }
    }
}
