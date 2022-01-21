using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{//conceito de repositorio generico. Conciste em oferecer todos o metodos necessarios para qualquer entidade.
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {//obrigar que faça dispose para liberar memoria, este t entity sera utililizada somente se for filha da entity
     //using System;
     //Por ser generico ele tera um TEntity. E por padrão tera um IDisposable, onde(where) essa TEntity so podra ser utilizada se ela for uma classe filha de Entity.
     //IDisposable (Fornece um mecanismo para liberar recursos não gerenciados.)
     //O uso principal dessa interface é liberar recursos não gerenciados.O coletor de lixo libera automaticamente a memória alocada para um objeto gerenciado quando esse objeto não é mais usado.No entanto, não é possível prever quando ocorrerá a coleta de lixo. Além disso, o coletor de lixo não tem conhecimento de recursos não gerenciados, como identificadores de janela, arquivos e fluxos abertos
     //Use o método Dispose dessa interface explicitamente para liberar recursos não gerenciados em conjunto com o coletor de lixo.O consumidor de um objeto pode chamar esse método quando o objeto não é mais necessário.

        Task Adicionar(TEntity entity);
        // Existe um metodo adicionar que ser recebida aqui somente se for filha de entity
        //Metodo de adicionar. Estou informando que " Existe um metodo adicionar, onde qualquer entidade que for recebida em TEntity sera aceita, desde que ela seja filha de Entity.
        //Irei repetir este comando para todos os metodos que vou oferecer tambem.
        // Quando eu tenho uma task apenas, ou a task e um metado ela sera um metodo void. Não retorna nada.
       
        Task<TEntity> ObterPorId(Guid id);
        //recebo uma guid que ira retorna uma task do tipo entity.
        //Lembrando que o metodo task e um metodo void. Quando declado da forma acima eu falo que irei retorna a propria entidade ou uma lista, como no exeplo abaixo.
        //Aqui irei receber um Guid, e retornarei uma task do tipo Entity. Deste jeito a task ira retorna a entidade.
        //Task<TResult> Classe = Representa uma operação assíncrona que pode retornar um valor.
        // Quando voce possui uma  Task <TEntity> você retorna alguma coisa, ou a entidade. Ou no caso a baixo vocÊ retorna uma lista
        Task<List<TEntity>> ObterTodos();
        // Aqui peço o retorno de uma lista da entidade informada. Eu recebo o obtertodos e retorno a entidade como lista. 

        Task Atualizar(TEntity entity);
        //Informo que: existe um metodo atualizar, que sera recebida em TEntity e so sera aceita, desde que ela seja filha de Entity.

        Task Remover(Guid id);
        // Informo que: Existe um metodo remover. Sera um metodo void. O item a ser removido sera identificado atraves do id.

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        //buscar qualquer entidade por qualquer paramentro.
        // Este e o metodo busco, onde voce vai passar uma Expression(expressão lambda) que ira trabaçhar com uma func, que vai comparar sua entitade com alguma coisa, desde que ela retorne um boolean, o que chamamos de predicate.
        // Ou seja, estou possibilitando que você passe uma expressão lambda, dentro deste metodo para buscar qualquer entidade por qualquer paramentro.
        // func = Encapsula um método que tem um parâmetro e retorna um valor do tipo especificado pelo parâmetro TResult.
        Task<int> SaveChanges();
        //Persiste todas as atualizações na fonte de dados e redefine o controle de alterações no contexto de objeto.
    }
}