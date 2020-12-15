using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkersInfo.Entities;

namespace Workers.Web.Models
{
    public class WorkerSelectionModel
    {
        public int Id { get; set; }
        [Display(Name ="ПІБ")]
        public string Name { get; set; }
        [Display(Name = "Посада")]
        public string Post { get; set; }
        [Display(Name = "Підрозділ")]
        public string Unit { get; set; }
        [Display(Name = "Стаж")]
        public int? Exp { get; set; }
        public static explicit operator WorkerSelectionModel(Worker worker)
        {
            return new WorkerSelectionModel()
            {
                Id = worker.Id,
                Name = worker.Name,
                Post = worker.Post.Name,
                Unit = worker.Unit,
                Exp = worker.Exp,
            };
        }

    }
}