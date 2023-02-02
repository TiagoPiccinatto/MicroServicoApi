
using Catalogo.Domain.Entities;
using Microsoft.Data.SqlClient;
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
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "sql.bsite.net\\MSSQL2016",
            InitialCatalog = "tpiccinatto_CatalogoApi",
            IntegratedSecurity = false,
            TrustServerCertificate = true,
            UserID = "tpiccinatto_CatalogoApi",
            Password = "123456"
        };

        optionsBuilder.UseSqlServer(builder.ConnectionString);
        }

        public DbSet<Produto> produtos { get; set; }
    }


}




