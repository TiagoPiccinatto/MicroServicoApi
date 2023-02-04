using Catalogo.Domain.Entities;
using Catalogo.Domain.Interface;
using Catalogo.Infra.Context;
using System.Linq.Expressions;

namespace Catalogo.Infra.Repositorio
{
    

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _catalogoContext;
        public ProdutoRepository(CatalogoContext catalogoContext)
        {
            _catalogoContext = catalogoContext;
        }

        //public List<Produto> GetProdutos()
        //{
        //    var getproduto = _catalogoContext.produtos.ToList();
        //    var produto = new List<Produto>();
        //    getproduto.ForEach(x =>
        //    {
        //        produto.Add(new Produto
        //        {
        //            Nome = x.Nome,
        //            Descricao = x.Descricao,
        //            Peso = x.Peso,
        //            ProdutoId = x.ProdutoId,
        //            TabelaNutricional = x.TabelaNutricional
        //        });
        //    });                  
        //    return produto;
        //}

        // Get Refatorado
        public List<Produto> GetProdutos()
        {
            return _catalogoContext.produtos.Select(x => new Produto
            {
                Nome = x.Nome,
                Descricao = x.Descricao,
                Peso = x.Peso,
                ProdutoId = x.ProdutoId,
                TabelaNutricional = x.TabelaNutricional
            }).ToList();
        }

        public Produto Salvar(Produto produto)
        {
            _catalogoContext.produtos.Add(produto);
            _catalogoContext.SaveChangesAsync().Wait();
            return produto;
        }

        //public void Delete(int id)
        //{          
        //    _catalogoContext.produtos.Remove(_catalogoContext.produtos.Where(x => x.ProdutoId == id).FirstOrDefault());          
        //    _catalogoContext.tabelaNutricionals.Remove(_catalogoContext.tabelaNutricionals.Where(x => x.Id == id).FirstOrDefault());
        //    _catalogoContext.SaveChanges();
        //}
        public void Delete(int id)
        {
            var Getproduto = _catalogoContext.produtos.Find(id);
            var tabelaNutricional = _catalogoContext.tabelaNutricionals.Find(id);
            if (Getproduto != null && tabelaNutricional != null)
            {
                _catalogoContext.produtos.Remove(Getproduto);
                _catalogoContext.tabelaNutricionals.Remove(tabelaNutricional);
            }                                
            _catalogoContext.SaveChanges();
        }

        public Produto Atualizar(int id, Produto produto)
        {
            var GetProduto = _catalogoContext.produtos.Find(id);
            var tabelaNutricional = _catalogoContext.tabelaNutricionals.Find(id);
            if (GetProduto != null && tabelaNutricional != null)
            {
                GetProduto.TabelaNutricional = tabelaNutricional;
                GetProduto.Nome = produto.Nome;
                GetProduto.Descricao = produto.Descricao;
                GetProduto.Peso = produto.Peso;
                _catalogoContext.produtos.Update(GetProduto);
                _catalogoContext.SaveChanges();
                return GetProduto;
            }
            
            throw new Exception("Produto Nao Encontrado");
        }
    }
}
