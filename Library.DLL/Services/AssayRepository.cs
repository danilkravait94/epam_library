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
    /// Service for working with assays
    /// </summary>
    public class AssayRepository : IRepository<Assay>
    {
        private readonly LibraryContext db;
        /// <summary>
        /// Constructor
        /// </summary>
        public AssayRepository(LibraryContext context)
        {
            db = context;
        }
        /// <summary>
        /// Create and add to database
        /// </summary>
        /// <param name="item">created item</param>
        public void Create(Assay item)
        {
            item.AssayID = GetAll().Count() + 1;
            db.Assays.Add(item);
        }
        /// <summary>
        /// Delete an item from db
        /// </summary>
        /// <param name="item">deleted item</param>
        public void Delete(Assay item)
        {
            db.Assays.Remove(item);
        }
        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id) => Delete(Get(id));
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

        /// <summary>
        /// Find a list of assays
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>IEnumerable of assay</returns>
        public IEnumerable<Assay> Find(Func<Assay, bool> predicate) => db.Assays.Where(predicate);
        /// <summary>
        /// Get an assay by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Assay Get(int id) => db.Assays.Find(id);

        /// <summary>
        /// get all assays
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Assay> GetAll() => db.Assays;
        /// <summary>
        /// Change item in database
        /// </summary>
        /// <param name="item"></param>
        public void Update(Assay item)
        {
            Delete(item.AssayID);
            db.Assays.Add(item);
        }
    }
}
