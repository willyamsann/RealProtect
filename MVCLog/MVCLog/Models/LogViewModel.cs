using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLog.Models
{
    public class LogViewModel
    {
        public int Id { get; set; }

        public string Ip { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

    }
}
