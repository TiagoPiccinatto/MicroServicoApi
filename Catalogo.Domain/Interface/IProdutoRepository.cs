using Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interface
{
    public interface IProdutoRepository
    {
        public Produto Salvar(Produto produto);

        public List<Produto> GetProdutos();


    }
}
