
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.Entities
{
    public class Worker:CountingEntity<Worker>
    { 
        private string name;
        private Post post;
        public string Unit { get; set; }

        private int? exp;
        public string Kharakteristika { get; set; }
        public string Bio { get; set; }
     
        public string StringIdentifier
        {
            get
            {
                return Name;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ПІБ працівника не може бути пустим", name);
                }
                value = value.Trim();
                if (value.Length < 4 || value.Length > 100)
                {
                    throw new FormatException("ПІБ працівника повинне містити від 4 до 100 символів");
                }
                name = value;
            }
        }
        public int? Exp
        {
            get
            {
                return exp;
            }
            set
            {

                if (value < 0)
                {
                    throw new FormatException("Стаж не може бути від'ємним");
                }
                exp = value;
            }
        }
        public Post Post
        {
            get => post;
            set => post = value ?? throw new ArgumentNullException();
        }
        public Worker(string name, Post post, string unit, int? exp)
        {
            Name = name;
            Post = post;
            Unit = unit;        
            Exp = exp;
        }
        public Worker(string name, Post post) : this(name, post, null, null) { }

        public Worker()
        {

        }
    }
}
