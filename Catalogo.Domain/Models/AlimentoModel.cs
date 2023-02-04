using Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Models
{
    public class AlimentoModel
    {
        public TabelaNutricional tabelaNutricionals = new TabelaNutricional();

        public Produto produtos = new Produto();

        public List<TabelaNutricional> tabela { get; set; }

        public List<Produto> produto { get; set; }
    }

}
