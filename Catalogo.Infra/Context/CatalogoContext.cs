
using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infra.Context
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Produto> produtos { get; set; }

    }
}
