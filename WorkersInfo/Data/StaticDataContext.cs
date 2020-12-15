using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersInfo.Entities;
using WorkersInfo.IO;

namespace WorkersInfo.Data
{
    public class StaticDataContext
    {

        private static DataContext dataContext = new DataContext("");
           

        public static ICollection<Worker> Workers
        {
            get { return dataContext.Workers; }
        }
        public static ICollection<Post> Posts
        {
            get { return dataContext.Posts; }
        }

        //private static string directory;
        public static string Directory
        {
            get { return dataContext.Directory; }
            set
            {
                dataContext.Directory = value;
            }
        }

        public  static string FilePath
        {
            get
            {
                return Path.Combine(Directory,"WorkersInfo.xml");
            }
        }
       
        public static void CreateTestingData()
        {
            dataContext.CreateTestingData();
        }

        public static void Load()
        {
                    
            dataContext.Load();
        }

        public static void Save()
        {
            dataContext.Save();
        }
       
    }
}
