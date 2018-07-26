using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WeightTracker.Models
{
    public class WeightContext : DbContext
    {
        public DbSet<WeightEntry> WeightEntries { get; set; }
        
    }
}