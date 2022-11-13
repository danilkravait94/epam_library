using Library.BLL.Interfaces;
using Library.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Library.Helpers
{
    /// <summary>
    /// class for making datelist
    /// </summary>
    public static class TagHelper
    {
        /// <summary>
        /// make datelist
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MvcHtmlString MakeTagList(this HtmlHelper html,string[] tags)
        {
            StringBuilder result = new StringBuilder();
            //TagBuilder datalist = new TagBuilder("datalist");
            for (int i = 0; i < tags.Length; i++)
            {
                TagBuilder tag = new TagBuilder("option");
                tag.InnerHtml = tags[i];
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}