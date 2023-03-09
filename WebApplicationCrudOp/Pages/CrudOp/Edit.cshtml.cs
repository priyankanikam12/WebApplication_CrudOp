using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCrudOp.Data;
using WebApplicationCrudOp.OpModel;

namespace WebApplicationCrudOp.Pages.CrudOp
{
    public class EditModel : PageModel
    {
        private readonly WebApplicationCrudOp.Data.WebApplicationCrudOpContext _context;

        public EditModel(WebApplicationCrudOp.Data.WebApplicationCrudOpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentCrudOp StudentCrudOp { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentCrudOp == null)
            {
                return NotFound();
            }

            var studentcrudop =  await _context.StudentCrudOp.FirstOrDefaultAsync(m => m.ID == id);
            if (studentcrudop == null)
            {
                return NotFound();
            }
            StudentCrudOp = studentcrudop;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentCrudOp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentCrudOpExists(StudentCrudOp.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentCrudOpExists(int id)
        {
          return _context.StudentCrudOp.Any(e => e.ID == id);
        }
    }
}
