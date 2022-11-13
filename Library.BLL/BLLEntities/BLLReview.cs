using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.BLLEntities
{
    /// <summary>
    /// Review object class
    /// </summary>
    public class BLLReview : BLLEntity
    {
        /// <summary>
        /// Text of review
        /// </summary>
        [Required]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Текст должен быть больше 10 символов и меньше 500")]
        public string ReviewText { get; set; }
        /// <summary>
        /// A name of author the review
        /// </summary>
        [Required(ErrorMessage = "Вы не ввели имя")]
        [StringLength(15, ErrorMessage = "Имя не может привышать 15 символов")]
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
        public BLLReview(string reviewName, string reviewText, DateTime reviewDate)
        {
            this.ReviewText = reviewText;
            this.ReviewName = reviewName;
            this.ReviewDate = reviewDate;
        }
        /// <summary>
        /// no parameter constructor
        /// </summary>
        public BLLReview()
        {

        }
    }
}
