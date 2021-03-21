using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogsProject.Models
{
    [Table("LogsProject")]
    public class Log
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