using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Models
{
    public class Scheduled
    {
        public int Id { get; set; }

        public int WorkOrder { get; set; }

        public string CustomerName { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }

        public string ThemeColor { get; set; }

        public bool IsFullDay { get; set; }
    }
}
