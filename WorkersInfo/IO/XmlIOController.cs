using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WorkersInfo.Data;
using WorkersInfo.Data.Interfaces;
using WorkersInfo.Entities;


namespace WorkersInfo.IO
{
    public  class XmlIOController
    {
        public string FileExtension { get; set; }
        public XmlIOController()
        {
            FileExtension = ".xml";
        }
        private void WriterPosts(IEnumerable<Post> collection, XmlWriter writer)
        {
            writer.WriteStartElement("PostsData");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("Post");
                writer.WriteElementString("Id", inst.Id.ToString());
                writer.WriteElementString("Name", inst.Name);
                writer.WriteElementString("Code", inst.Code);
                writer.WriteElementString("State_Units", inst.State_Units.ToString());
                writer.WriteElementString("Notice", inst.Notice);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        private void WriteWorkers(IEnumerable<Worker> collection, XmlWriter writer)
        {
            writer.WriteStartElement("WorkersData");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("Worker");
                writer.WriteElementString("Id", inst.Id.ToString());
                writer.WriteElementString("Name", inst.Name);
                int PostId;
                if (inst.Post == null)
                {
                    PostId = 0;
                }
                else
                {
                    PostId = inst.Post.Id;
                }
                writer.WriteElementString("PostId", PostId.ToString());              
                writer.WriteElementString("Unit", inst.Unit);
              
                writer.WriteElementString("Exp", inst.Exp.ToString());
                writer.WriteElementString("Bio", inst.Bio);
                writer.WriteElementString("Kharakteristika", inst.Kharakteristika);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        private void WriteData(IDataSet dataSet, XmlWriter writer)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("WorkersInfo");
            WriterPosts(dataSet.Posts, writer);
            WriteWorkers(dataSet.Workers, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        public void Save(IDataSet dataSet, string filepath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;
            string filename = Path.ChangeExtension(filepath, FileExtension);
            XmlWriter writer = null;
            try
            {
                writer = XmlWriter.Create(filename, settings);
                WriteData(dataSet, writer);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

        }
        private  void ReadPost(XmlReader reader, ICollection<Post> collection)
        {
            Post inst = new Post();
            reader.ReadStartElement("Post");
            inst.Id = reader.ReadElementContentAsInt();
            inst.Name = reader.ReadElementContentAsString();
            inst.Code = reader.ReadElementContentAsString();
            string StateUnits = reader.ReadElementContentAsString();
            inst.State_Units = string.IsNullOrEmpty(StateUnits) ? (int?)null : int.Parse(StateUnits);
            inst.Notice = reader.ReadElementContentAsString();
            collection.Add(inst);
        }
        private static void ReadWorker(XmlReader reader, IDataSet dataSet)
        {
            Worker inst = new Worker();
            reader.ReadStartElement("Worker");
            inst.Id = reader.ReadElementContentAsInt();
            inst.Name = reader.ReadElementContentAsString();
            int PostId = reader.ReadElementContentAsInt();
            inst.Post =dataSet.Posts.FirstOrDefault(el => el.Id == PostId);
            inst.Unit = reader.ReadElementContentAsString();           
            string Exp_ = reader.ReadElementContentAsString();
            inst.Exp = string.IsNullOrEmpty(Exp_) ? (int?)null : int.Parse(Exp_);
            inst.Bio = reader.ReadElementContentAsString();
            inst.Kharakteristika = reader.ReadElementContentAsString();
            dataSet.Workers.Add(inst);
        }
        public void Load(string filepath, IDataSet dataSet)
        {
            string fileName = Path.ChangeExtension(filepath, FileExtension);
            if (!File.Exists(fileName)) return;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(fileName, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "Post": ReadPost(reader,dataSet.Posts); break;
                            case "Worker": ReadWorker(reader,dataSet); break;
                        }
                    }
                }
            }
        }
    }
}
