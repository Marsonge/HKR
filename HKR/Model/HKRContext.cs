using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HKR.Model
{
    public class HKRContext : DbContext
    {
        public HKRContext(DbContextOptions<HKRContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
    }
}
