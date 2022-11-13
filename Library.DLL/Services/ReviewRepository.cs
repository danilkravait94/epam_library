using Library.DLL.EF;
using Library.DLL.Entities;
using Library.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Services
{
    /// <summary>
    /// Service for working with reviews
    /// </summary>
    public class ReviewRepository : IRepository<Review>
    {
        private readonly LibraryContext db;
        /// <summary>
        /// Constructor
        /// </summary>
        public ReviewRepository(LibraryContext context)
        {
            db = context;
        }
        /// <summary>
        /// Create and add to database
        /// </summary>
        /// <param name="item">created item</param>
        public void Create(Review item)
        {
            item.ReviewID = GetAll().Count() + 1;
            db.Reviews.Add(item);
        }
        /// <summary>
        /// Delete an item from db
        /// </summary>
        /// <param name="item">deleted item</param>
        public void Delete(Review item)
        {
            db.Reviews.Remove(item);
        }
        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id) => Delete(Get(id));

        /// <summary>
        /// Find a list of review
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>IEnumerable of forms</returns>
        public IEnumerable<Review> Find(Func<Review, bool> predicate) => db.Reviews.Where(predicate);
        /// <summary>
        /// Get a review by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Review Get(int id) => db.Reviews.Find(id);
        /// <summary>
        /// get all Reviews
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Review> GetAll() => db.Reviews;
        /// <summary>
        /// Change item in database
        /// </summary>
        /// <param name="item"></param>
        public void Update(Review item)
        {
            Delete(item.ReviewID);
            db.Reviews.Add(item);
        }
        /// <summary>
        /// Private bool type for disposed
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// dispose with param
        /// </summary>
        /// <param name="disposing"> disposing bool</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        /// <summary>
        /// public implemention of dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
