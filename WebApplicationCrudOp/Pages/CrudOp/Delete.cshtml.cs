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
    public class DeleteModel : PageModel
    {
        private readonly WebApplicationCrudOp.Data.WebApplicationCrudOpContext _context;

        public DeleteModel(WebApplicationCrudOp.Data.WebApplicationCrudOpContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StudentCrudOp == null)
            {
                return NotFound();
            }
            var studentcrudop = await _context.StudentCrudOp.FindAsync(id);

            if (studentcrudop != null)
            {
                StudentCrudOp = studentcrudop;
                _context.StudentCrudOp.Remove(StudentCrudOp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
