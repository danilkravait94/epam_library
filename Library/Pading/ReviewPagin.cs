using Library.Models;
using Library.Pading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Pading
{
    /// <summary>
    /// helper class for pagin
    /// </summary>
    public class ReviewPagin
    {
        /// <summary>
        /// Review
        /// </summary>
        public ReviewViewModel Review { get; set; }
        /// <summary>
        /// page information
        /// </summary>
        public IndexViewReview IndexViewReview { get; set; }
    }
}