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
    /// Review module binding
    /// </summary>
    public class ReviewModule : NinjectModule
    {
        /// <summary>
        /// bind method for review
        /// </summary>
        public override void Load()
        {
            Bind<IReviewService>().To<ReviewService>();
        }
    }
}