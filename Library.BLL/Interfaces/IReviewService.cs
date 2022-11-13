using Library.BLL.BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    /// <summary>
    /// Review service
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// Method for creating an item
        /// </summary>
        /// <param name="item">Item that will be inserted to database</param>
        void Create(BLLReview item);
        /// <summary>
        /// Get a item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BLLReview Get(int? id);
        /// <summary>
        /// check if name is exist in database
        /// </summary>
        /// <param name="name">insert name</param>
        /// <returns></returns>
        bool CheckName(string name);

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        IEnumerable<BLLReview> GetAll();
        /// <summary>
        /// Dispose method
        /// </summary>
        void Dispose();
    }
}
