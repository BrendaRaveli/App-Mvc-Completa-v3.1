using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {//meapeando utilizando o fluent api. Faz o mapeamento da classe de produto e tem que herdar de IEntityTypeConfiguration de produto
        public void Configure(EntityTypeBuilder<Produto> builder)
        {//implementado a classe e fazendo o mapeamento.
            builder.HasKey(p => p.Id);
            //chave primaria. Sua chave e id.
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
            //o campo recebe nome, é obrigatorio, que contem letras e numeros, tamanho maximo 200.
            //O termo varchar refere-se a um tipo de dados de um campo (ou coluna) em um sistema de gerenciamento de banco de dados que pode conter letras e números.
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");
           //recebe nome, campo obrigatorio, que contem letras e numeros

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Produtos");
            //define o nome da tabela
        }
    }
}