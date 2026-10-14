using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    public class EventItem
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public EventItem(string title, string category, DateTime date, string description)
        {
            Title = title;
            Category = category;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date:dd MMM yyyy} | {Category} | {Title}";
        }
    }
}