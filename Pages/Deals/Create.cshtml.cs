using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesTracker_RJLOZANSKI.Models;

namespace SalesTracker_RJLOZANSKI.Pages_Deals
{
    public class CreateModel : PageModel
    {
        private readonly SalesTracker_RJLOZANSKI.Models.AppDbContext _context;

        public CreateModel(SalesTracker_RJLOZANSKI.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SalesRepID"] = new SelectList(_context.SalesReps, "SalesRepID", "FullName");
            return Page();
        }

        [BindProperty]
        public Deal Deal { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Deals.Add(Deal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
