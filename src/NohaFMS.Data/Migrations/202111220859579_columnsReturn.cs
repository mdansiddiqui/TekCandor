namespace NohaFMS.Data.Migrations
{
    
    using System.Data.Entity.Migrations;
    
    public partial class columnsReturn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReturnReason", "Description", c => c.String(maxLength: 8000, unicode: false));

        }

        public override void Down()
        {
            AlterColumn("dbo.ReturnReason", "DescriptionWithReturnCodes", c => c.String(maxLength: 4000));
        }
    }
}
