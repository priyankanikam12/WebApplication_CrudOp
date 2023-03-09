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
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationCrudOp.Data.WebApplicationCrudOpContext _context;

        public DetailsModel(WebApplicationCrudOp.Data.WebApplicationCrudOpContext context)
        {
            _context = context;
        }

      public StudentCrudOp StudentCrudOp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentCrudOp == null)
            {
                return NotFound();
            }

            var studentcrudop = await _context.StudentCrudOp.FirstOrDefaultAsync(m => m.ID == id);
            if (studentcrudop == null)
            {
                return NotFound();
            }
            else 
            {
                StudentCrudOp = studentcrudop;
            }
            return Page();
        }
    }
}
