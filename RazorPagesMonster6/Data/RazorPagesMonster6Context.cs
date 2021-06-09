using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMonster6.models;

namespace RazorPagesMonster6.Data
{
    public class RazorPagesMonster6Context : DbContext
    {
        public RazorPagesMonster6Context (DbContextOptions<RazorPagesMonster6Context> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMonster6.models.Monster> Monster { get; set; }
    }
}
