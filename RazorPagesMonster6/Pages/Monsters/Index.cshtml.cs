using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMonster6.Data;
using RazorPagesMonster6.models;

namespace RazorPagesMonster6.Pages.Monsters
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMonster6.Data.RazorPagesMonster6Context _context;

        public IndexModel(RazorPagesMonster6.Data.RazorPagesMonster6Context context)
        {
            _context = context;
        }

        public IList<Monster> Monster { get;set; }

        public async Task OnGetAsync()
        {
            Monster = await _context.Monster.ToListAsync();
        }
    }
}
