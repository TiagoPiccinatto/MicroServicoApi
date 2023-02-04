using Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interface
{
    public interface IProdutoService
    {
        public List<Produto> GetProdutos();
        public Produto SalvarProduto(Produto produto);
        public void DeleteProduto(int id);
    }
}
