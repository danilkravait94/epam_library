using Library.BLL.BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    /// <summary>
    /// Form service
    /// </summary>
    public interface IFormService
    {
        /// <summary>
        /// Method for creating an item
        /// </summary>
        /// <param name="item">Item that will be inserted to database</param>
        void Create(BLLForm item);
        /// <summary>
        /// Get a item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BLLForm Get(int? id);
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        IEnumerable<BLLForm> GetAll();
        /// <summary>
        /// Dispose method
        /// </summary>
        void Dispose();
    }
}
