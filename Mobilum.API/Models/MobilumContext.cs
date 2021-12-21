using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilum.API.Models
{
    public class MobilumContext : DbContext
    {
        public MobilumContext(DbContextOptions<MobilumContext> options) : base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }
    }
}
