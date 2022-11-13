using AutoMapper;
using Library.BLL.BLLEntities;
using Library.BLL.Exceptions;
using Library.BLL.Interfaces;
using Library.DLL.Entities;
using Library.DLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    /// <summary>
    /// Servise for reviews
    /// </summary>
    public class ReviewService : IReviewService
    {
        /// <summary>
        /// Review repository
        /// </summary>
        UnitOfWork DB { get; set; }
        /// <summary>
        /// Construcor
        /// </summary>
        public ReviewService(UnitOfWork db)
        {
            DB = db;
        }
        /// <summary>
        /// Get all reviews
        /// </summary>
        /// <returns>a list of reviews</returns>
        public IEnumerable<BLLReview> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Review, BLLReview>()).CreateMapper();
            return mapper.Map<IEnumerable<Review>, List<BLLReview>>(DB.Reviews.GetAll());
        }

        /// <summary>
        /// Check Name
        /// </summary>
        /// <returns>true if exist overwise false</returns>
        public bool CheckName(string name)
        {
            return DB.Reviews.GetAll().Any(Review => Review.ReviewName == name);
        }


        /// <summary>
        /// Get a review by id
        /// </summary>
        /// <param name="id"> the id of item</param>
        /// <returns>Review</returns>
        public BLLReview Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id отзыва", "");
            var review = DB.Reviews.Get(id.Value);
            if (review == null)
                throw new ValidationException("Отзыв не найден", "");

            return new BLLReview()
            {
                ReviewName = review.ReviewName,
                ReviewDate = review.ReviewDate,
                ReviewText = review.ReviewText,
            };
        }
        /// <summary>
        /// Create a review 
        /// </summary>
        /// <param name="item">the review</param>
        public void Create(BLLReview item)
        {
            if (item is null)
            {
                throw new ValidationException("Не установлен отзыв", "");
            }
            Review review = new Review
            {
                ReviewName = item.ReviewName,
                ReviewDate = item.ReviewDate,
                ReviewText = item.ReviewText,
            };

            DB.Reviews.Create(review);
            DB.Save();
        }
        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            DB.Reviews.Dispose();
        }
    }
}
