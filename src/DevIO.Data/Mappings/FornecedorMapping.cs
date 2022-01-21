using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


// a classe que possui as filhas com faz o mapeamento.
namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
            //o campo recebe nome, é obrigatorio, que contem letras e numeros, tamanho maximo 200.

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");
            //o campo recebe nome, é obrigatorio, que contem letras e numeros, tamanho maximo 100.

            builder.HasOne(f => f.Endereco)// o fornecedor tem 1 endereço
                .WithOne(e => e.Fornecedor);//o endereço tem fornecedor
            // 1 : 1 => Fornecedor : Endereco

            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);//chave estrangeira
            // 1 : N => Fornecedor : Produtos
            // receber um fornecedor que pode ter varios produtos.

            builder.ToTable("Fornecedores");
        }
    }
}