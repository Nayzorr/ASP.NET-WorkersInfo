
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersInfo.Data.Interfaces;
using WorkersInfo.Entities;
using WorkersInfo.IO;

namespace WorkersInfo.Data
{
    public  class DataContext:IDataSet
    {
        private DataSet dataSet = new DataSet();
        public ICollection<Post> Posts
        {
            get { return dataSet.Posts; }
        }

        public ICollection<Worker> Workers
        {
            get { return dataSet.Workers; }
        }

        public string FileName { get; set; }

        private string directory;

        public string Directory
        {
            get { return directory; }
            set
            {
                directory = value ?? "";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
        }
        public DataContext()
        {
            FileName = "WorkersInfo";
            Directory = "files";
        }

        public DataContext(string directory)
        {
            FileName = "WorkersInfo";
    
        }
       private XmlIOController fileIOController = new XmlIOController();


        public void Save(string filePath)
        {
            fileIOController.Save(dataSet, filePath);
        }

        public void Save()
        {
            Save(Path.Combine(Directory, FileName));
        }

        public void Load(string filePath)
        {          
            fileIOController.Load(filePath,dataSet);
        }
      
        public void Load()
        {
            
            Load(Path.Combine(Directory, FileName));
        }

        public void Clear()
        {
            Workers.Clear();
            Posts.Clear();          
        }
        public void CreateTestingData()
        {
            CreatePosts();
            CreateWorkers();
        }
      

        private void CreatePosts()
        {          
            Posts.Add(new Post("Програміст", "26719", 10) {
                
                Id = 1,
                Notice= "Програміст — фахівець, що займається програмуванням, виконує розробку " +
                "програмного забезпечення (в простіших випадках — окремих програм) для програмованих пристроїв, " +
                "які, як правило містять один процесор чи більше."
            });
            Posts.Add(new Post("Дизайнер", "98246", 5) {
                Id = 2,
                Notice= "Професія дизайнер на сучасному ринку праці є однією з найбільш затребуваних. " +
                "Це й не дивно, адже дизайнер займається такою діяльністю," +
                " яка дозволяє зробити людське життя яскравіше і красивіше"

            });
            Posts.Add(new Post("Тестувальник", "28401", 7) {
                Id = 3 ,
                Notice= "Тестувальник – це повноцінна робоча одиниця великої або " +
                "малої команди спеціалістів, які працюють на єдиний результат." +
                " Саме від тестера найбільше залежить, кінцева якість продукту"
            });
            Posts.Add(new Post("Менеджер", "24321", null)
            {
                Id = 4,
                Notice = "Менеджер – це людина, що професійно займається " +
                "управлінською діяльністю, що повсякденно керує функціями" +
                " фірми з метою збереження її основних пропорцій;"
            });
        }

        private  void CreateWorkers()
        {         
            Workers.Add(new Worker("Шванов Сергій Володимирович", Posts.FirstOrDefault(el => el.Name == "Програміст"), ".Net Розробник", 5) { Id = 1, Bio="Новий працівник" });
            Workers.Add(new Worker("Лозова Аліна Анатоліївна", Posts.FirstOrDefault(el => el.Name == "Дизайнер"), "3D-Дизайнер", 4) { Id = 2 });
            Workers.Add(new Worker("Кріпак Олександр Макарович", Posts.FirstOrDefault(el => el.Name == "Програміст"), "Веб-розробник", null) { Id = 3 });
            Workers.Add(new Worker("Возілевський Леонід Андрійович", Posts.FirstOrDefault(el => el.Name == "Тестувальник"), "Тестувальник ПО", 3) { Id = 4 });
            Workers.Add(new Worker("Ломаченко Олександр Іванович", Posts.FirstOrDefault(el => el.Name == "Тестувальник"), null, 7) { Id = 5 });
            Workers.Add(new Worker("Федоренко Оксана Василівна", Posts.FirstOrDefault(el => el.Name == "Дизайнер"), null, null) { Id = 6 });
            Workers.Add(new Worker("Баланов Руслан Ігорович", Posts.FirstOrDefault(el => el.Name == "Програміст"), null, 8) { Id = 7 });
            Workers.Add(new Worker("Харченко Іван Іванович", Posts.FirstOrDefault(el => el.Name == "Менеджер"), "Менеджер по рекламі", 4) { Id = 8 });

        }
 
    }
}
