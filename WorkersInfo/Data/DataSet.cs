using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersInfo.Data.Interfaces;
using WorkersInfo.Entities;

namespace WorkersInfo.Data
{
    [Serializable]
    public class DataSet : IDataSet
    {

        public List<Post> Posts { get; private set; }
        public List<Worker> Workers { get; private set; }

        public DataSet()
        {
            Posts = new List<Post>();
            Workers = new List<Worker>();
        }

        ICollection<Post> IDataSet.Posts
        {
            get { return Posts; }
        }

        ICollection<Worker> IDataSet.Workers
        {
            get { return Workers; }
        }
    }
}
