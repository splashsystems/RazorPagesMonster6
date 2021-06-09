using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MonsterGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Monster
                                            orderby m.Genre
                                            select m.Genre;
            //LINQ query - defined, not run
            var monsters = from m in _context.Monster
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                monsters = monsters.Where(s => s.MonsterName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MonsterGenre))
            {
                monsters = monsters.Where(x => x.Genre == MonsterGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Monster = await monsters.ToListAsync();
        }
    }
}
