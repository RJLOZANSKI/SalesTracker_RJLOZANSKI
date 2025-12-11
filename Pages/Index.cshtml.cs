using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesTracker_RJLOZANSKI.Models;

namespace SalesTracker_RJLOZANSKI.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SalesTracker_RJLOZANSKI.Models.AppDbContext _context;

    public IndexModel(ILogger<IndexModel> logger, SalesTracker_RJLOZANSKI.Models.AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public int TotalDeals { get; set; }
    public int TotalSalesReps { get; set; }
    public decimal TotalDealWonValue { get; set; }
    public int OpenDeals { get; set; }

    public IList<Deal> TopDeals { get; set; } = new List<Deal>();

    public void OnGet()
    {
        TotalDeals = _context.Deals.Count();
        TotalSalesReps = _context.SalesReps.Count();
        TotalDealWonValue = _context.Deals.Where(d => d.Status == "Won").Sum(d => d.DealValue);
        OpenDeals = _context.Deals.Count(d => d.Status == "Open");

        TopDeals = _context.Deals.Include(d => d.SalesRep).Where(d => d.Status == "Won").ToList().OrderByDescending(d => d.DealValue).Take(5).ToList();
    }
}
