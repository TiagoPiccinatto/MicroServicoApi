using Catalogo.Domain.Entities;
using Catalogo.Domain.Interface;
using Catalogo.Infra.Context;

namespace Catalogo.Infra.Repositorio
{
    

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _catalogoContext;
        public ProdutoRepository(CatalogoContext catalogoContext)
        {
            _catalogoContext = catalogoContext;
        }

        public List<Produto> GetProdutos()
        {
          return _catalogoContext.produtos.ToList();
        }

        public Produto Salvar(Produto produto)
        {
            _catalogoContext.produtos.Add(produto);
            _catalogoContext.SaveChanges();
            return produto;
        }
    }
}
