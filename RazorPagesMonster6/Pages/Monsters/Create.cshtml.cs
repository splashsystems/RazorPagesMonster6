using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMonster6.Data;
using RazorPagesMonster6.models;

namespace RazorPagesMonster6.Pages.Monsters
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMonster6.Data.RazorPagesMonster6Context _context;

        public CreateModel(RazorPagesMonster6.Data.RazorPagesMonster6Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Monster Monster { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Monster.Add(Monster);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
