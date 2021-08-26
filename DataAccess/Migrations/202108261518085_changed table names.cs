namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtablenames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MakeEntities", newName: "VehicleMakes");
            RenameTable(name: "dbo.ModelEntities", newName: "VehicleModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.VehicleModels", newName: "ModelEntities");
            RenameTable(name: "dbo.VehicleMakes", newName: "MakeEntities");
        }
    }
}
