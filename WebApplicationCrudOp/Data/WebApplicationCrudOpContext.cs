using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationCrudOp.OpModel;

namespace WebApplicationCrudOp.Data
{
    public class WebApplicationCrudOpContext : DbContext
    {
        public WebApplicationCrudOpContext (DbContextOptions<WebApplicationCrudOpContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationCrudOp.OpModel.StudentCrudOp> StudentCrudOp { get; set; } = default!;
    }
}
