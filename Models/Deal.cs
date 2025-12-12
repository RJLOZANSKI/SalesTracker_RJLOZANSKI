using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace SalesTracker_RJLOZANSKI.Models;

public class Deal
{
    public int DealID { get; set; }

    [Display(Name = "Customer Name")]
    [StringLength(100, MinimumLength = 3)]
    public string CustomerName { get; set; } = string.Empty;

    [Display(Name = "Product Type")]
    [StringLength(30, MinimumLength = 3)]
    public string ProductType { get; set; } = string.Empty;

    [Display(Name = "Deal Value")]
    [DataType(DataType.Currency)]
    public decimal DealValue { get; set; }

    [AllowedValues("Won", "Lost", "Open", ErrorMessage = "Status must be 'Won', 'Lost', or 'Open'.")]
    public string Status { get; set; } = string.Empty;

    [Display(Name = "Close Date")]
    [DataType(DataType.Date)]
    public DateTime CloseDate { get; set; }

    [Display(Name = "Sales Executive")]
    public int SalesRepID { get; set; }
    public SalesRep? SalesRep { get; set; }
}