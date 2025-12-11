using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace SalesTracker_RJLOZANSKI.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.SalesReps.Any())
        {
            return;
        }

        context.SalesReps.AddRange(
            new SalesRep
            {
                SalesRepID = 1,
                FirstName = "James T.",
                LastName = "Kirk",
                Territory = "Alpha Quadrant Sector 001",
                HireDate = DateTime.Parse("01/15/2265"),
                MonthQuota = 75000m
            },
            new SalesRep
            {
                SalesRepID = 2,
                FirstName = "Jean-Luc",
                LastName = "Picard",
                Territory = "Federation Diplomatic Sector",
                HireDate = DateTime.Parse("03/01/2264"),
                MonthQuota = 95000m
            },
            new SalesRep
            {
                SalesRepID = 3,
                FirstName = "Nyota",
                LastName = "Uhura",
                Territory = "Federation Communications Region",
                HireDate = DateTime.Parse("06/10/2266"),
                MonthQuota = 65000m
            },
            new SalesRep
            {
                SalesRepID = 4,
                FirstName = "Leonard",
                LastName = "McCoy",
                Territory = "Medical Commerce Zone",
                HireDate = DateTime.Parse("09/05/2265"),
                MonthQuota = 50000m
            },
            new SalesRep
            {
                SalesRepID = 5,
                FirstName = "Montgomery",
                LastName = "Scott",
                Territory = "Engineering Systems Sector",
                HireDate = DateTime.Parse("11/20/2264"),
                MonthQuota = 85000m
            },
            new SalesRep
            {
                SalesRepID = 6,
                FirstName = "Hikaru",
                LastName = "Sulu",
                Territory = "Tactical Systems Region",
                HireDate = DateTime.Parse("02/18/2266"),
                MonthQuota = 70000m
            }
        );

        context.SaveChanges();

        if (context.Deals.Any())
        {
            return;
        }

        context.Deals.AddRange(
        // Deals for Kirk (1)
        new Deal
        {
            DealID = 1,
            SalesRepID = 1,
            CustomerName = "Starfleet Academy",
            ProductType = "Quantum Fiber Uplink",
            DealValue = 22000m,
            Status = "Won",
            CloseDate = DateTime.Parse("03/10/2268")
        },
        new Deal
        {
            DealID = 2,
            SalesRepID = 1,
            CustomerName = "Kobayashi Maru Training Fleet",
            ProductType = "Mobility Subspace Upgrade",
            DealValue = 12500m,
            Status = "Open",
            CloseDate = DateTime.Parse("04/15/2268")
        },
        new Deal
        {
            DealID = 3,
            SalesRepID = 1,
            CustomerName = "Starbase 1",
            ProductType = "Secure Federation Backbone",
            DealValue = 31000m,
            Status = "Won",
            CloseDate = DateTime.Parse("05/21/2268")
        },
        new Deal
        {
            DealID = 4,
            SalesRepID = 1,
            CustomerName = "Deep Space Station K-7",
            ProductType = "Cargo Bay Fiber Retrofit",
            DealValue = 18000m,
            Status = "Lost",
            CloseDate = DateTime.Parse("04/02/2268")
        },

        // Deals for Picard (2)
        new Deal
        {
            DealID = 5,
            SalesRepID = 2,
            CustomerName = "Vulcan Science Council",
            ProductType = "Logic-Optimized Data Grid",
            DealValue = 30000m,
            Status = "Won",
            CloseDate = DateTime.Parse("02/15/2366")
        },
        new Deal
        {
            DealID = 6,
            SalesRepID = 2,
            CustomerName = "Federation High Command",
            ProductType = "Predictive Analytics Node",
            DealValue = 18000m,
            Status = "Lost",
            CloseDate = DateTime.Parse("01/30/2366")
        },
        new Deal
        {
            DealID = 7,
            SalesRepID = 2,
            CustomerName = "Daystrom Institute",
            ProductType = "AI Research Network Uplink",
            DealValue = 42000m,
            Status = "Won",
            CloseDate = DateTime.Parse("06/12/2366")
        },
        new Deal
        {
            DealID = 8,
            SalesRepID = 2,
            CustomerName = "Federation Council Science Division",
            ProductType = "High-Precision Data Channel",
            DealValue = 19500m,
            Status = "Open",
            CloseDate = DateTime.Parse("07/01/2366")
        },

        // Deals for Uhura (3)
        new Deal
        {
            DealID = 9,
            SalesRepID = 3,
            CustomerName = "Universal Translator Initiative",
            ProductType = "Multilingual Bandwidth",
            DealValue = 14800m,
            Status = "Open",
            CloseDate = DateTime.Parse("06/20/2268")
        },
        new Deal
        {
            DealID = 10,
            SalesRepID = 3,
            CustomerName = "Communications Division HQ",
            ProductType = "Secure Fiber Channel",
            DealValue = 21000m,
            Status = "Won",
            CloseDate = DateTime.Parse("03/25/2268")
        },
        new Deal
        {
            DealID = 11,
            SalesRepID = 3,
            CustomerName = "Subspace Relay Network",
            ProductType = "Signal Boost Node Upgrade",
            DealValue = 17400m,
            Status = "Won",
            CloseDate = DateTime.Parse("05/05/2268")
        },
        new Deal
        {
            DealID = 12,
            SalesRepID = 3,
            CustomerName = "Federation News Service",
            ProductType = "Priority Transmission Link",
            DealValue = 13200m,
            Status = "Lost",
            CloseDate = DateTime.Parse("04/18/2268")
        },

        // Deals for McCoy (4)
        new Deal
        {
            DealID = 13,
            SalesRepID = 4,
            CustomerName = "Starfleet Medical",
            ProductType = "Biometric Data Transport",
            DealValue = 19500m,
            Status = "Won",
            CloseDate = DateTime.Parse("02/28/2268")
        },
        new Deal
        {
            DealID = 14,
            SalesRepID = 4,
            CustomerName = "Federation Hospitals Network",
            ProductType = "Remote Neural Scanner Uplink",
            DealValue = 9900m,
            Status = "Open",
            CloseDate = DateTime.Parse("07/05/2268")
        },
        new Deal
        {
            DealID = 15,
            SalesRepID = 4,
            CustomerName = "Frontier Colony Clinic Beta-5",
            ProductType = "Emergency Triage Comm",
            DealValue = 8700m,
            Status = "Won",
            CloseDate = DateTime.Parse("06/01/2268")
        },
        new Deal
        {
            DealID = 16,
            SalesRepID = 4,
            CustomerName = "Medical Research Station Regulus",
            ProductType = "Encrypted Lab Data Link",
            DealValue = 15200m,
            Status = "Lost",
            CloseDate = DateTime.Parse("05/09/2268")
        },

        // Deals for Scotty (5)
        new Deal
        {
            DealID = 17,
            SalesRepID = 5,
            CustomerName = "Warp Systems Engineering Group",
            ProductType = "High-Energy Fiber Conduit",
            DealValue = 27500m,
            Status = "Won",
            CloseDate = DateTime.Parse("01/20/2268")
        },
        new Deal
        {
            DealID = 18,
            SalesRepID = 5,
            CustomerName = "Dilithium Research Labs",
            ProductType = "Reinforced Data Transfer Array",
            DealValue = 17300m,
            Status = "Lost",
            CloseDate = DateTime.Parse("03/02/2268")
        },
        new Deal
        {
            DealID = 19,
            SalesRepID = 5,
            CustomerName = "Utopia Planitia Shipyards",
            ProductType = "Fleet Fabrication Network",
            DealValue = 36500m,
            Status = "Won",
            CloseDate = DateTime.Parse("04/27/2268")
        },
        new Deal
        {
            DealID = 20,
            SalesRepID = 5,
            CustomerName = "Enterprise Refit Program",
            ProductType = "Core Systems Fiber Overhaul",
            DealValue = 45800m,
            Status = "Open",
            CloseDate = DateTime.Parse("06/28/2268")
        },

        // Deals for Sulu (6)
        new Deal
        {
            DealID = 21,
            SalesRepID = 6,
            CustomerName = "Helm Navigation Systems",
            ProductType = "Real-Time Tactical Data Feed",
            DealValue = 11400m,
            Status = "Open",
            CloseDate = DateTime.Parse("03/22/2268")
        },
        new Deal
        {
            DealID = 22,
            SalesRepID = 6,
            CustomerName = "Fleet Weapons Division",
            ProductType = "Targeting Sensor Fiber Sync",
            DealValue = 23700m,
            Status = "Won",
            CloseDate = DateTime.Parse("02/12/2268")
        },
        new Deal
        {
            DealID = 23,
            SalesRepID = 6,
            CustomerName = "Astrometrics Division",
            ProductType = "Long-Range Sensor Data Link",
            DealValue = 16900m,
            Status = "Won",
            CloseDate = DateTime.Parse("05/30/2268")
        },
        new Deal
        {
            DealID = 24,
            SalesRepID = 6,
            CustomerName = "Klingon Trade Delegation",
            ProductType = "Neutral Zone Comms",
            DealValue = 20400m,
            Status = "Lost",
            CloseDate = DateTime.Parse("04/08/2268")
        },

        // Extra deals
        new Deal
        {
            DealID = 26,
            SalesRepID = 2,
            CustomerName = "Terraforming Command",
            ProductType = "Planetary Operations Network",
            DealValue = 33200m,
            Status = "Won",
            CloseDate = DateTime.Parse("06/22/2366")
        },
        new Deal
        {
            DealID = 27,
            SalesRepID = 3,
            CustomerName = "Federation Diplomatic Corps",
            ProductType = "Embassy Communications Suite",
            DealValue = 19100m,
            Status = "Open",
            CloseDate = DateTime.Parse("06/30/2268")
        },
        new Deal
        {
            DealID = 28,
            SalesRepID = 4,
            CustomerName = "Frontier Outpost Triage Center",
            ProductType = "Crisis Response Data Node",
            DealValue = 13400m,
            Status = "Won",
            CloseDate = DateTime.Parse("03/18/2268")
        }
        );

        context.SaveChanges();


    }
}