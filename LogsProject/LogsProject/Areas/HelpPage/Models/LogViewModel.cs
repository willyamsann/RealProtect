using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogsProject.Areas.HelpPage.Models
{
    public class LogViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Ip { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        [StringLength(1050)]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}