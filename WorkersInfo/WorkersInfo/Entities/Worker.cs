using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public string Unit { get; set; }
        public int? Exp { get; set; }
        public string Kharaktiristika { get; set; }
        public string Bio { get; set; }
    }
}
