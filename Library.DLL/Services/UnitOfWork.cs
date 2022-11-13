using Library.DLL.EF;
using Library.DLL.Entities;
using Library.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Services
{
    /// <summary>
    /// Class for work with DataBase
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext DB;
        private AssayRepository assayRepository;
        private FormRepository formRepository;
        private ReviewRepository reviewRepository;
        /// <summary>
        /// constructor
        /// </summary>

        public UnitOfWork(/*string connection*/)
        {
            DB = new LibraryContext();
        }
        /// <summary>
        /// Get Assays
        /// </summary>
        public IRepository<Assay> Assays
        {
            get
            {
                if (assayRepository is null)
                    assayRepository = new AssayRepository(DB);
                return assayRepository;
            }
        }

        /// <summary>
        /// Get form repository
        /// </summary>
        public IRepository<Form> Forms
        {
            get
            {
                if (formRepository is null)
                    formRepository = new FormRepository(DB);
                return formRepository;
            }
        }
        /// <summary>
        /// Get form repository
        /// </summary>
        public IRepository<Review> Reviews
        {
            get
            {
                if (reviewRepository is null)
                    reviewRepository = new ReviewRepository(DB);
                return reviewRepository;
            }
        }

        /// <summary>
        /// Save DataBase
        /// </summary>
        public void Save()
        {
            DB.SaveChanges();
        }
    }

}
