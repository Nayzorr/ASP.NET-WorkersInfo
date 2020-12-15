using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersInfo.Entities;

namespace WorkersInfo.Data.Interfaces
{
    public interface IDataSet
    {
        ICollection<Post> Posts { get; }
        ICollection<Worker> Workers { get; }
    }
}
