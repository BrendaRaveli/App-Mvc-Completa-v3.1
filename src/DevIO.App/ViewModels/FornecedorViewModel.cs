using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// A view model tem como finalidade exibir coisas na tela.
namespace DevIO.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [DisplayName("Tipo")]
        public int TipoFornecedor { get; set; }
        
        public EnderecoViewModel Endereco { get; set; }
        //Relação direta com endereço


        [DisplayName("Ativo?")]
        //Esta é a forma como o MVC ira escrever o nome desta propriedade na tela. É necessario importa o using System.ComponentModel;
        public bool Ativo { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        //Declaração da propriedades. Para o entity entender que e o fornecedor tem um relação de 1 pra muitos com produto.

    }
}