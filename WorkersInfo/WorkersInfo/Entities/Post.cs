using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? State_Units { get; set; }
        public string Notice { get; set; }
    }
}
