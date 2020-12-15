using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Workers.Web.Helpers
{
    public static class InfoHelpers
    {
        public static MvcHtmlString InfoHeader(this HtmlHelper html, string header)
        {
            return MvcHtmlString.Create(string.Format(
                "<h3><strong>{0}</strong></h3>", header));
        }
        public static MvcHtmlString ValueInfo<T>(this HtmlHelper html, string name, T value)
        {
            return MvcHtmlString.Create(string.Format("<strong class=\"lead\">{0}: {1}</strong></br>", name, value));
        }
        public static MvcHtmlString StringInfo(this HtmlHelper html, string info)
        {
            return MvcHtmlString.Create(string.Format("<strong=\"lead\">{0}</strong></br>", info));
        }
        public static MvcHtmlString Descriptive_Block(this HtmlHelper html, string infoString)
        {
            if (string.IsNullOrWhiteSpace(infoString))
            {
                return MvcHtmlString.Create("(Дані відсутні)");
            }
            else
            {
                return MvcHtmlString.Create("<blockquote><p class=\"lead\">" + infoString + "</p></blockquote>");
            }
        }
        public static MvcHtmlString DescriptiveInfo(this HtmlHelper html, IEnumerable<string> infoStrings)
        {
            StringBuilder sb = new StringBuilder();
            if (infoStrings != null)
            {
                sb.Append("</hr>");
                foreach(var s in infoStrings)
                {
                    sb.AppendFormat("<p class=\"lead\">{0}</p>", s);
                }
                sb.Append("</hr>");
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}