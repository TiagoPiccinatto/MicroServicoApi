using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Entities
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; } = "";
        public double Peso { get; set; }
        public string Descricao { get; set; } = "";

        public TabelaNutricional TabelaNutricional { get; set; }

    }
}
