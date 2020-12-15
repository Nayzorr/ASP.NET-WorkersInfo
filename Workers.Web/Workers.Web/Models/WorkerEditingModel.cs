using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using WorkersInfo.Entities;

namespace Workers.Web.Models
{
    public class WorkerEditingModel
    {
        public int Id { get; set; }
        [Display(Name = "ПІБ")]
        [Required(ErrorMessage ="Потрібно вказати ПІБ працівника")]
        [StringLength(60,MinimumLength =4,ErrorMessage ="Довжина поля повинна бути від 4 до 60 символів")]
        public string Name { get; set; }
        [Display(Name = "Посада")]
        [Required(ErrorMessage ="Потрібно вибрати зі списку")]
        public string Post { get; set; }
        [Display(Name = "Підрозділ")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Довжина поля повинна бути від 2 до 30 символів")]
      
        public string Unit { get; set; }      
        [Display(Name = "Стаж")]
        [Range(0,60,ErrorMessage ="Значення повинно бути від 0 до 60")]       
        public int? Exp { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Характеристика")]
        public string Kharakteristika { get; set; }
        [Display(Name = "Біографія")]
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }
       
        public static explicit operator WorkerEditingModel(Worker worker)
        {
            return new WorkerEditingModel()
            {
                Id = worker.Id,
                Name = worker.Name,
                Post = worker.Post.Name,
               
                Unit = worker.Unit,
                Exp = worker.Exp,
                Kharakteristika = worker.Kharakteristika,
                Bio=worker.Bio
            };
        }
        public static Worker ToWorker(WorkerEditingModel worker, IEnumerable<Post> posts)
        {
            return new Worker()
            {
                Id = worker.Id,
                Name = worker.Name,
                Post = posts.FirstOrDefault(el => el.Name == worker.Post),
                Unit = worker.Unit,
                
                Exp = worker.Exp,
                Bio = worker.Bio,
                Kharakteristika = worker.Kharakteristika
            };
        }
    }
}