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
    /// Service for working with forms
    /// </summary>
    public class FormRepository : IRepository<Form>
    {
        private readonly LibraryContext db;
        /// <summary>
        /// Constructor
        /// </summary>
        public FormRepository(LibraryContext context)
        {
            db = context;
        }
        /// <summary>
        /// Create and add to database
        /// </summary>
        /// <param name="item">created item</param>
        public void Create(Form item)
        {
            item.FormID = GetAll().Count() + 1;
            db.Forms.Add(item);
        }
        /// <summary>
        /// Delete an item from db
        /// </summary>
        /// <param name="item">deleted item</param>
        public void Delete(Form item)
        {
            db.Forms.Remove(item);
        }
        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id) => Delete(Get(id));

        /// <summary>
        /// Find a list of forms
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>IEnumerable of forms</returns>
        public IEnumerable<Form> Find(Func<Form, bool> predicate) => db.Forms.Where(predicate);
        /// <summary>
        /// Get a form by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Form Get(int id) => db.Forms.Find(id);
        /// <summary>
        /// get all forms
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Form> GetAll() => db.Forms;
        /// <summary>
        /// Change item in database
        /// </summary>
        /// <param name="item"></param>
        public void Update(Form item)
        {
            Delete(item.FormID);
            db.Forms.Add(item);
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
