using System.ComponentModel.DataAnnotations;

namespace SalesTracker_RJLOZANSKI.Models;

public class SalesRep
{
    public int SalesRepID { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Sales Executive")]
    public string FullName => $"{FirstName} {LastName}";

    public string Territory { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; }

    [DataType(DataType.Currency)]
    public decimal MonthQuota { get; set; }

    public ICollection<Deal>? Deals { get; set; } = new List<Deal>();  
}