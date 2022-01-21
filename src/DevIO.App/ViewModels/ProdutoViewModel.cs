using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DevIO.App.Extensions;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Http;


//configuração DE... PARA...
namespace DevIO.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        // Para informa que o id sempre sera uma chave, e não um campo.
        public Guid Id { get; set; }
        // O id do produto


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Produto")]
        public IFormFile ImagemUpload { get; set; }
        //Aqui eu inform que o campo imagem ira fazer um upload de um documento

        public string Imagem { get; set; }
        //Eu tenho que manter este campo para ser gerado o campo com o scaffold


        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        //Aqui eu inform que quando for fazer o scaffold, ignore este campo.

        public DateTime DataCadastro { get; set; }
        //A data cadastro não sera requerida pois sera preenchida no momento do cadastro no banco


        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }

        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}