using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        //Esta interface ira implementar o IRepository de fornecedor. Tudo que fizer aqui, sera para forneceder. Utilizara os metodos ja foram informado em IRepository.
        //Ira estender o IRepository para Fornecedor.
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        // Aqui eu irie obter a informação de fornecedor e endereco no mesmo objeto.

        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
        // Aqui eu irie obter a informação de fornecedor, lista de produto e endereco em uma unica chamada de metodo.

    }
}