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
    public class DetailsModel : PageModel
    {
        private readonly SalesTracker_RJLOZANSKI.Models.AppDbContext _context;

        public DetailsModel(SalesTracker_RJLOZANSKI.Models.AppDbContext context)
        {
            _context = context;
        }

        public Deal Deal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals.FirstOrDefaultAsync(m => m.DealID == id);

            if (deal is not null)
            {
                Deal = deal;

                return Page();
            }

            return NotFound();
        }
    }
}
