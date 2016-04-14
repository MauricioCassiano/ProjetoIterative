namespace ToDo.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommitInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Observacoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTarefa = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Descricao = c.String(maxLength: 600),
                        Tarefa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Tarefa", t => t.Tarefa_Id)
                .Index(t => t.Tarefa_Id);
            
            CreateTable(
                "dbo.Tbl_Tarefa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Date = c.DateTime(),
                        Finalizado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Observacoes", "Tarefa_Id", "dbo.Tbl_Tarefa");
            DropIndex("dbo.Tbl_Observacoes", new[] { "Tarefa_Id" });
            DropTable("dbo.Tbl_Tarefa");
            DropTable("dbo.Tbl_Observacoes");
        }
    }
}
