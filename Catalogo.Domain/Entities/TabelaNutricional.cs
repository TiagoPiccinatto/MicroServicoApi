using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Entities
{
    public class TabelaNutricional
    {
        [Key]
        public int Id { get; set; }       
        public string Nome { get; set; } = "";
        public string Calorias { get; set; } = "";
        public string Carboidratos { get; set; } = "";
        public string Proteínas { get; set; } = "";
        public string GordurasTotais { get; set; } = "";
        public string GordurasSaturadas { get; set; } = "";
        public string FibraAlimentar { get; set; } = "";
        public string Sodio { get; set; } = "";
        public int ProdutoId { get; set; }
    }
}
