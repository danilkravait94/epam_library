using Library.BLL.Interfaces;
using Library.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Util
{
    /// <summary>
    /// assay module binding
    /// </summary>
    public class AssayModule : NinjectModule
    {
        /// <summary>
        /// bind method for assay
        /// </summary>
        public override void Load()
        {
            Bind<IAssayService>().To<AssayService>();
        }
    }
}