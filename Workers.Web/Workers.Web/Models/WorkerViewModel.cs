using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkersInfo.Entities;

namespace Workers.Web.Models
{
    public class WorkerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "ПІБ працівника")]
        public string Name { get; set; }
        [Display(Name = "Посада")]
        public string Post { get; set; }
        [Display(Name = "Підрозділ")]
        public string Unit { get; set; }
        [Display(Name = "Стаж")]
        public int? Exp { get; set; }
        [ScaffoldColumn(false)]
        public bool HasInfo { get; set; }

        public static explicit operator WorkerViewModel(Worker obj)
        {
            return new WorkerViewModel()
            {
                Id = obj.Id,
                Name = obj.Name,
                Post = obj.Post.Name,
                Unit = obj.Unit,
                Exp = obj.Exp,
                HasInfo= !string.IsNullOrEmpty(obj.Kharakteristika)|| !string.IsNullOrEmpty(obj.Bio)
            };
        }
    }
}