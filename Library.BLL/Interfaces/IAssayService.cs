using Library.BLL.BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    /// <summary>
    /// Assay service
    /// </summary>
    public interface IAssayService
    {
        /// <summary>
        /// Method for creating an item
        /// </summary>
        /// <param name="item">Item that will be inserted to database</param>
        void Create(BLLAssay item);
        /// <summary>
        /// Method for updating an item
        /// </summary>
        /// <param name="item">Item that will be update</param>
        void Update(BLLAssay item);
        /// <summary>
        /// Get a item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BLLAssay Get(int? id);
        /// <summary>
        /// get array of tag
        /// </summary>
        /// <returns></returns>
        string[] GetTags();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        IEnumerable<BLLAssay> GetAll();
        /// <summary>
        /// Dispose method
        /// </summary>
        void Dispose();
    }
}
