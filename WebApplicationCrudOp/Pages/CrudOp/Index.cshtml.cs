using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationCrudOp.Data;
using WebApplicationCrudOp.OpModel;

namespace WebApplicationCrudOp.Pages.CrudOp
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationCrudOp.Data.WebApplicationCrudOpContext _context;

        public IndexModel(WebApplicationCrudOp.Data.WebApplicationCrudOpContext context)
        {
            _context = context;
        }

        public IList<StudentCrudOp> StudentCrudOp { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.StudentCrudOp != null)
            {
                StudentCrudOp = await _context.StudentCrudOp.ToListAsync();
            }
        }
    }
}
