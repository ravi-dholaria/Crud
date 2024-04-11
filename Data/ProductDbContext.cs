using Crud.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Data
{
    internal class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
           
        }
    }
}
