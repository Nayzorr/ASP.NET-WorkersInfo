using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkersInfo.Entities;

namespace Workers.Web.Models
{
    public class WorkerTableModel
    {
        public int Id { get; set; }

        [Display(Name = "ПІБ")]
        public string Name { get; set; }

        [Display(Name = "Назва посади")]
        public string Post { get; set; }

        [Display(Name = "Назва підрозділу")]
        public string Unit { get; set; }

        [Display(Name = "Стаж")]
        public int? Exp { get; set; }
        public static explicit operator WorkerTableModel(Worker obj)
        {
            return new WorkerTableModel()
            {
                Id = obj.Id,
                Name = obj.Name,
                Post = obj.Post.Name,
                Unit = obj.Unit,
                Exp = obj.Exp
            };
        }
    }
}