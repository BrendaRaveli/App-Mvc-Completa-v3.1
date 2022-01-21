using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {    // Irei herda de repository de produto, e implemento a interface IProdutoRepository

        public ProdutoRepository(MeuDbContext context) : base(context) { }
        // aqui eu crio um construto, que inform que irie receber o db context e passa para a classe base o contexto

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
            // Aqui eu estou indo em produtos, fazendo um join com fornecedor, aonde o produto tem esse id. E retornando esta informação.

        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
            // Aqui eu quero obter todos os dados dos produtos com os dados do fornecedores e ordenando eles por nome em uma lista. 

        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
            //aqui eu retorno um buscar, onde o fornecedor id dele e igual ao fornecedor id.

        }
    }
}