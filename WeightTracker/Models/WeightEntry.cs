using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeightTracker.Models
{
    public class WeightEntry
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }

        public WeightEntry()
        {

        }

        // used only in date formatter function
        private List<string> months = new List<string>
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        };

        public string DateFormatter(DateTime date)
        {
            return months[date.Month] + " " + date.Day + ", " + date.Year;

        }

    }
}