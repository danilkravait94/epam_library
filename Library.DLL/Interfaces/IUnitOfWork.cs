using Library.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Interfaces
{
    /// <summary>
    /// pattern UnitOfWork interface
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repository for working with assays
        /// </summary>
        IRepository<Assay> Assays { get; }
        /// <summary>
        /// Repository for working with forms
        /// </summary>
        IRepository<Form> Forms { get; }
        /// <summary>
        /// Repository for working with reviews
        /// </summary>
        IRepository<Review> Reviews { get; }
        /// <summary>
        /// save method
        /// </summary>
        void Save();
    }
}
