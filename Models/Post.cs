using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";

        public string Description { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string Category { get; set; } = "";

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
