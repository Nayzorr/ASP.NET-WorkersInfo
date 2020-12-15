using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkersInfo.Entities;

namespace Workers.Web.Models
{
    public class WorkerInfoModel
    {
        public int Id { get; set; }

        [Display(Name ="ПІБ працівника")]
        public string Name { get; set; }
        [Display(Name ="Посада")]
        public string Post { get; set; }
        [Display(Name = "Підрозділ")]
        public string Unit { get; set; }
        [Display(Name = "Стаж")]
        public int? Exp { get; set; }

        public string[] Info { get; private set; }
        private static string[] CreateInfo(Worker worker)
        {
            string s = null;
            if (!string.IsNullOrEmpty(worker.Kharakteristika))
            {
                s += "Характеристика:" + worker.Kharakteristika + "\n";
            }
            if (!string.IsNullOrEmpty(worker.Bio))
            {
                s += "Біографія:" + worker.Bio + "\n";
            }
            string[] Info = null;
            if (s != null)
            {
                Info = s.Split(new[] {'\n'},StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            return Info;
        }
        public static explicit operator WorkerInfoModel(Worker worker)
        {
            return new WorkerInfoModel()
            {
                Name = worker.Name,
                Post = worker.Post.Name,
                Unit = worker.Unit,
                Exp = worker.Exp,
                Info = CreateInfo(worker),
            };
        }

    }
}