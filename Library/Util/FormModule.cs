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
    /// form module binding
    /// </summary>
    public class FormModule : NinjectModule
    {
        /// <summary>
        /// bind method for form
        /// </summary>
        public override void Load()
        {
            Bind<IFormService>().To<FormService>();
        }
    }
}