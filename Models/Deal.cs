using System.ComponentModel.DataAnnotations;

namespace SalesTracker_RJLOZANSKI.Models;

public class Deal
{
    public int DealID { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public string CustomerName { get; set; } = string.Empty;

    [StringLength(30, MinimumLength = 3)]
    public string ProductType { get; set; } = string.Empty;

    public decimal DealValue { get; set; }

    public string Status { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime CloseDate { get; set; }

    public int SalesRepID { get; set; }
    public SalesRep? SalesRep { get; set; } = default!;
}