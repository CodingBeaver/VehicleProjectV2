namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newproject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MakeEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Abrv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MakeId = c.Guid(nullable: false),
                        Name = c.String(),
                        Abrv = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MakeEntities", t => t.MakeId, cascadeDelete: true)
                .Index(t => t.MakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelEntities", "MakeId", "dbo.MakeEntities");
            DropIndex("dbo.ModelEntities", new[] { "MakeId" });
            DropTable("dbo.ModelEntities");
            DropTable("dbo.MakeEntities");
        }
    }
}
