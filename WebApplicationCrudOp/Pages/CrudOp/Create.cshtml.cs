using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationCrudOp.Data;
using WebApplicationCrudOp.OpModel;

namespace WebApplicationCrudOp.Pages.CrudOp
{
    public class CreateModel : PageModel
    {
        private readonly WebApplicationCrudOp.Data.WebApplicationCrudOpContext _context;

        public CreateModel(WebApplicationCrudOp.Data.WebApplicationCrudOpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentCrudOp StudentCrudOp { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentCrudOp.Add(StudentCrudOp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
