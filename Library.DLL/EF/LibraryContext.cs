using Library.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.EF
{
    /// <summary>
    /// Context of db
    /// </summary>
    public class LibraryContext : DbContext
    {
        static LibraryContext()
        {
            Database.SetInitializer(new DBInitializer());
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public LibraryContext(/*string connection*/) : base("DBConnection"/*connection*/)
        { }
        /// <summary>
        /// DbSet of Assays
        /// </summary>
        public DbSet<Assay> Assays { get; set; }
        /// <summary>
        /// DbSet of Forms
        /// </summary>
        public DbSet<Form> Forms { get; set; }
        /// <summary>
        /// DbSet of Reviews
        /// </summary>
        public DbSet<Review> Reviews { get; set; }
    }
}
