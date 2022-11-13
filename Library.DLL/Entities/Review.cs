using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Entities
{
    /// <summary>
    /// Review object class
    /// </summary>
    public class Review 
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ReviewID { get; set; }
        /// <summary>
        /// Text of review
        /// </summary>
        public string ReviewText { get; set; }
        /// <summary>
        /// A name of author the review
        /// </summary>
        public string ReviewName { get; set; }
        /// <summary>
        /// Date of posting review
        /// </summary>
        public DateTime ReviewDate { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="reviewText"> text of review</param>
        /// <param name="reviewName"> author`s name</param>
        /// <param name="reviewDate">Date of posting</param>
        public Review(string reviewName, string reviewText, DateTime reviewDate)
        {
            this.ReviewText = reviewText;
            this.ReviewName = reviewName;
            this.ReviewDate = reviewDate;
        }
        /// <summary>
        /// no parameter constructor
        /// </summary>
        public Review()
        {

        }
    }
}
