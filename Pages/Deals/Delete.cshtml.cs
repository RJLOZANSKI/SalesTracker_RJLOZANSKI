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
    public class DeleteModel : PageModel
    {
        private readonly SalesTracker_RJLOZANSKI.Models.AppDbContext _context;

        public DeleteModel(SalesTracker_RJLOZANSKI.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals.FindAsync(id);
            if (deal != null)
            {
                Deal = deal;
                _context.Deals.Remove(Deal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
