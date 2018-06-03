namespace AmbasadaAPI.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Podnosilac",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        naziv = c.String(nullable: false),
                        email = c.String(nullable: false),
                        datumRodjenja = c.DateTime(nullable: false),
                        jmbg = c.String(nullable: false),
                        dodatneInformacije = c.String(),
                        mjestoPrebivalista = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Prijava",
                c => new
                    {
                        id = c.Int(nullable: false),
                        vrijemePrijave = c.DateTime(nullable: false),
                        stanjePrijave = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Podnosilac", t => t.id)
                .Index(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prijava", "id", "dbo.Podnosilac");
            DropIndex("dbo.Prijava", new[] { "id" });
            DropTable("dbo.Prijava");
            DropTable("dbo.Podnosilac");
        }
    }
}
