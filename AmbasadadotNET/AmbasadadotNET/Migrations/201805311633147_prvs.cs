namespace AmbasadadotNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prvs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Podnosilac",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        naziv = c.String(),
                        email = c.String(),
                        datumRodjenja = c.DateTime(nullable: false),
                        jmbg = c.String(),
                        dodatneInformacije = c.String(),
                        mjestoPrebivalista = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Prijava",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        vrijemePrijave = c.DateTime(nullable: false),
                        stanjePrijave = c.Boolean(nullable: false),
                        podnosilacPrijave_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Podnosilac", t => t.podnosilacPrijave_id)
                .Index(t => t.podnosilacPrijave_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prijava", "podnosilacPrijave_id", "dbo.Podnosilac");
            DropIndex("dbo.Prijava", new[] { "podnosilacPrijave_id" });
            DropTable("dbo.Prijava");
            DropTable("dbo.Podnosilac");
        }
    }
}
