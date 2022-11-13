using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Pading
{
    /// <summary>
    /// information about pages
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// number of current page
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// count of item on page
        /// </summary>
        public int PageSize { get; set; } 
        /// <summary>
        /// total count of items
        /// </summary>
        public int TotalItems { get; set; } 
        /// <summary>
        /// total count of pages
        /// </summary>
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    /// <summary>
    /// class index view model
    /// </summary>
    public class IndexViewAssay
    {
        /// <summary>
        /// assays enumerable
        /// </summary>
        public IEnumerable<AssayViewModel> Assays { get; set; }
        /// <summary>
        /// informaton avbout page
        /// </summary>
        public PageInfo PageInfo { get; set; }
    }
    /// <summary>
    /// class index view model
    /// </summary>
    public class IndexViewReview
    {
        /// <summary>
        /// assays enumerable
        /// </summary>
        public IEnumerable<ReviewViewModel> Reviews { get; set; }
        /// <summary>
        /// informaton avbout page
        /// </summary>
        public PageInfo PageInfo { get; set; }
    }
}