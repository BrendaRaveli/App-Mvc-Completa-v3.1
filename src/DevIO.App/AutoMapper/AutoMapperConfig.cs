using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Models;

namespace DevIO.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {        //Esta classe ira herda de profile de automapper. O profile esta aqui para informa que esta é uma classe de configuração de perfil de mapeamento.

        public AutoMapperConfig()
        {
            //No construtor irei passar a configuração DE... PARA. Eu transformo ex: fornecedor em fornecedorViewModel e vice e versa.
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}