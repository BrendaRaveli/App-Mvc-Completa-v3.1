using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {//meapeando utilizando o fluent api. Faz o mapeamento da classe de produto e tem que herdar de IEntityTypeConfiguration de endereço

        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            // aqui todos serão requeridos e serão varchar de algum tamanho
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");
            //o campo recebe nome, é obrigatorio, que contem letras e numeros, tamanho maximo 200.

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");
            //o campo recebe nome, é obrigatorio, que contem letras e numeros, tamanho maximo 50.

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");
            //o campo recebe nome, é obrigatorio, que contem letras e numeros, tamanho maximo 8.

            builder.Property(c => c.Complemento)
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Enderecos");
            // defino o nome de tabela endereço
        }
    }
}