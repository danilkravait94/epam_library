using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Helpers
{
    /// <summary>
    /// Class for crating list
    /// </summary>
    public static class ListMaker
    {
        /// <summary>
        /// mehtod that create a list
        /// </summary>
        /// <param name="html"></param>
        /// <param name="smths">list of smths</param>
        /// <returns>Htmlstring with a list</returns>
        public static MvcHtmlString CreateList(this HtmlHelper html, List<string> smths)
        {
            var ul = new TagBuilder("ul");

            foreach (var smth in smths)
            {
                var li = new TagBuilder("li");
                li.SetInnerText(smth);
                ul.InnerHtml += li;
            }
            return new MvcHtmlString(ul.ToString());
        }
    }
}