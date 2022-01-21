using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {//Esta interface ira implementar o IRepository de fornecedor. Tudo que fizer aqui, sera para forneceder. Utilizara os metodos ja foram informado em IRepository.
     //Ira estender o IRpository para Produto.

        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        // Aqui retorno uma lista de produtos por fornecedor, que sera localizado pelo id do fornecedor

        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        // Aqui retorno uma lista de produtos e fornecedores daquela produto, que sera localizado pelo id do fornecedor

        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}