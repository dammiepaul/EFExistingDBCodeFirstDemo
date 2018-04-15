namespace EFExistingDBCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagAndAuthorNameHaveLengthAndNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "Name", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}
