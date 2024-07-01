using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    public class Entry
    {
        public string Date { get; set; }
        public string Content { get; set; }

        public Entry(string date, string content)
        {
            Date = date;
            Content = content;
        }

        public override string ToString()
        {
            return $"{Date}\n{Content}";
        }
    }
}