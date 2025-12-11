using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string CurrentSearch { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Deals.Include(d => d.SalesRep).Select(d => d);

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(d => d.CustomerName.ToUpper().Contains(CurrentSearch.ToUpper()) ||
                                         d.Status.ToUpper().Contains(CurrentSearch.ToUpper()) ||
                                         d.SalesRep.FirstName.ToUpper().Contains(CurrentSearch.ToUpper()) ||
                                         d.SalesRep.LastName.ToUpper().Contains(CurrentSearch.ToUpper()));
            }

            switch (CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(d => d.CustomerName);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(d => d.CustomerName);
                    break;
                case "second_asc":
                    query = query.OrderBy(d => d.ProductType);
                    break;
                case "second_desc":
                    query = query.OrderByDescending(d => d.ProductType);
                    break;
                case "third_asc":  
                    query = query.OrderBy(d => d.Status);
                    break;
                case "third_desc":
                    query = query.OrderByDescending(d => d.Status);
                    break;
                case "fourth_asc":
                    query = query.OrderBy(d => d.CloseDate);
                    break;
                case "fourth_desc":
                    query = query.OrderByDescending(d => d.CloseDate);
                    break;
            }

            TotalPages = (int)Math.Ceiling(await query.CountAsync() / (double)PageSize);

            Deal = await query.Skip((PageNum - 1) * PageSize).Take(PageSize).ToListAsync();
        }
    }
}
