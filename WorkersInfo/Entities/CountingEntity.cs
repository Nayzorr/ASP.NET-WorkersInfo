using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.Entities
{
    public class CountingEntity<T>
    {
        public static int counter = 0;

        private int id;

        public CountingEntity()
        {
            id = ++counter;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                if (counter < value) counter = value;
            }
        }

    }
}
