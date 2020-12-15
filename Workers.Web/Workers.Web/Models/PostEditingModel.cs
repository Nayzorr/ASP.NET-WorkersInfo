using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkersInfo.Entities;

namespace Workers.Web.Models
{
    public class PostEditingModel
    {
        public int Id { get; set; }
        [Display(Name = "Назва посади")]
        [Required(ErrorMessage = "Потрібно вказати Назву посади")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Довжина поля повинна бути від 3 до 40 символів")]
        public string Name { get; set; }

        [Display(Name = "Код")]
        [Required(ErrorMessage = "Потрібно вказати код посади")]
        [RegularExpression(@"^[0-9]{5}")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Код посади має складатись з 5-ти цифр")]
        public string Code { get; set; }

        [Display(Name = "Штатні одиниці")]
        [Range(0, 100, ErrorMessage = "Значення повинно бути від 0 до 100")]
        public int? State_Units { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notice { get; set; }

        public static explicit operator PostEditingModel(Post post)
        {
            return new PostEditingModel()
            {
                Id = post.Id,
                Name = post.Name,
                Code = post.Code,
                State_Units = post.State_Units,
                Notice = post.Notice,

            };
        }
        public static explicit operator Post(PostEditingModel model)
        {
            return new Post()
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                State_Units = model.State_Units,
                Notice = model.Notice,
            };
        }
    }
}