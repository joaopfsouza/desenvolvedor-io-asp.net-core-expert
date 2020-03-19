using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhaDemoMVC.Models;

namespace MinhaDemoMVC.Data
{
    public class MinhaDemoMVCContext : DbContext
    {
        public MinhaDemoMVCContext (DbContextOptions<MinhaDemoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MinhaDemoMVC.Models.Filme> Filme { get; set; }
    }
}
