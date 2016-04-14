using ToDo.Domain;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Core.Data.Mappings
{
    public class ObservacaoMap : EntityTypeConfiguration<Observacao>
    {
        public ObservacaoMap()
        {
            this.ToTable("Tbl_Observacoes");

            this.Property(o => o.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(o => o.IdTarefa)
                .HasColumnName("IdTarefa")
                .IsRequired();

            this.Property(o => o.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(600);

            this.Property(o => o.Date)
                .HasColumnName("Date")
                .IsOptional();

            this.HasKey(o => o.Id);
        }
    }
}
