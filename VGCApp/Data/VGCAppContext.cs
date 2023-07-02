using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VGCApp.Models;

namespace VGCApp.Data
{
    public class VGCAppContext : DbContext
    {
        public VGCAppContext (DbContextOptions<VGCAppContext> options)
            : base(options)
        {
        }

        public DbSet<VGCApp.Models.VideoGameModel> VideoGameModel { get; set; } = default!;
        public DbSet<VGCApp.Models.Review> Reviews { get; set; } = default!;
    }
}
