using System.Web;
using System.Web.Mvc;

namespace Library
{
    /// <summary>
    /// filter config class
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// registration method
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
