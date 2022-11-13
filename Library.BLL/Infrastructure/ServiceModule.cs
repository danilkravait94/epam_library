using Library.DLL.Interfaces;
using Library.DLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Infrastructure
{
    /// <summary>
    /// Service module binding
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;
        /// <summary>
        /// constructor
        /// </summary>
        public ServiceModule(/*string connection*/)
        {
            //connectionString = connection;
        }
        /// <summary>
        /// bind method for unit of work
        /// </summary>
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();/*.WithConstructorArgument(connectionString);*/
        }
    }
}
