using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ToDo.Domain;

namespace ToDo.Core.Data.Mappings
{
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            this.ToTable("Tbl_Tarefa");

            this.Property(t => t.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Titulo)
                .HasColumnName("Titulo")
                .IsRequired();

            this.Property(t => t.Date)
                .HasColumnName("Date")
                .IsOptional();

            this.Property(t => t.Finalizado)
                .HasColumnName("Finalizado")
                .IsOptional();

            this.HasKey(t => t.Id);
        }
    }
}
