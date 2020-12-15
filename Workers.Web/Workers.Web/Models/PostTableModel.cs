using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkersInfo.Entities;

namespace Workers.Web.Models
{
    public class PostTableModel
    {
        public int Id { get; set; }

        [Display(Name = "Назва посади")]
        public string Name { get; set; }

        [Display(Name = "Код посади")]
        public string Code { get; set; }

        [Display(Name = "Штатні одиниці")]
        public int? State_Units { get; set; }
      
        public static explicit operator PostTableModel(Post obj)
        {
            return new PostTableModel()
            {
                Id = obj.Id,
                Name = obj.Name,
                Code= obj.Code,
                State_Units = obj.State_Units,             
            };
        }
    }
}