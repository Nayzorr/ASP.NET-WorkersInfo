using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkersInfo.Entities;

namespace Workers.Web.Models
{
    public class PostInfoModel
    {
        public int Id { get; set; }

        [Display(Name = "Назва посади")]
        public string Name { get; set; }
        [Display(Name = "Код")]
        public string Code { get; set; }
        [Display(Name = "Штатні одиниці")]
        public int? State_Units { get; set; }

        public string[] Info { get; private set; }

        private static string[] CreateInfo(Post post)
        {
            string s = null;
            if (!string.IsNullOrWhiteSpace(post.Notice))
            {
                s += "Примітка:\n" + post.Notice + "\n";
            }
            string[] info = null;
            if (s != null)
            {
                info = s.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return info;
        }
        public static explicit operator PostInfoModel(Post obj)
        {
            return new PostInfoModel()
            {
                Id = obj.Id,
                Name = obj.Name,
                Code = obj.Code,
                State_Units = obj.State_Units,
                Info = CreateInfo(obj),
            };
        }
    }
}