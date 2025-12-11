using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesTracker_RJLOZANSKI.Models;

namespace SalesTracker_RJLOZANSKI.Pages_Deals
{
    public class IndexModel : PageModel
    {
        private readonly SalesTracker_RJLOZANSKI.Models.AppDbContext _context;

        public IndexModel(SalesTracker_RJLOZANSKI.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Deal> Deal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Deal = await _context.Deals
                .Include(d => d.SalesRep).ToListAsync();
        }
    }
}
