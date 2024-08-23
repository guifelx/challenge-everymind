using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EverymindChallenge.Models;

namespace EverymindChallenge.Context
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options) : base (options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}