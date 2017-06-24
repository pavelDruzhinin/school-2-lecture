namespace lecture_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Name");
        }
    }
}
