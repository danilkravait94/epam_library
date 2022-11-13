using AutoMapper;
using Library.BLL.BLLEntities;
using Library.BLL.Interfaces;
using Library.Models;
using Library.Pading;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IAssayService assayService;
        /// <summary>
        /// no parameter controller
        /// </summary>
        public HomeController(IAssayService service)
        {
            assayService = service;
        }
        /// <summary>
        /// Get view with assays
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index(int page = 1)
        {
            var assays = assayService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BLLAssay, AssayViewModel>()).CreateMapper();
            var assayViews = mapper.Map<IEnumerable<BLLAssay>, IEnumerable<AssayViewModel>>(assays).Reverse();

            int pageSize = 4; 
            IEnumerable<AssayViewModel> assaysperpage = assayViews.Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = assayViews.Count() };
            IndexViewAssay ivm = new IndexViewAssay { PageInfo = pageInfo, Assays = assaysperpage };
            ViewBag.Tags = assayService.GetTags();
            return View(ivm);
        }
        /// <summary>
        /// index with tag argument
        /// </summary>
        /// <param name="page"> number of page</param>
        /// <param name="tag">tag string</param>
        /// <returns></returns>
        public ActionResult Assays(int page = 1,string tag="Triller")
        {
            var assays = assayService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BLLAssay, AssayViewModel>()).CreateMapper();
            var assayViews = mapper.Map<IEnumerable<BLLAssay>, IEnumerable<AssayViewModel>>(assays)
                .Where(w => w.Tags.Contains(tag)).Reverse();

            int pageSize = 4;
            IEnumerable<AssayViewModel> assaysperpage = assayViews.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = assayViews.Count() };
            IndexViewAssay ivm = new IndexViewAssay { PageInfo = pageInfo, Assays = assaysperpage };
            ViewBag.Tags = assayService.GetTags();
            return View(ivm);
        }
        /// <summary>
        /// Post a review
        /// </summary>
        /// <param name="collection">FormCollection</param>
        /// <returns> actionResult</returns>
        [HttpPost]
        public ActionResult AddComment(FormCollection collection)
        {
            var assays = assayService.GetAll();
            foreach (var assay in assays)
            {
                if(!string.IsNullOrEmpty(collection[$"{assay.Id}"]))
                {
                    if (!assay.Tags.Contains(collection[$"{assay.Id}"]))
                    {
                        assay.Tags.Add(collection[$"{assay.Id}"]);
                    }
                    assayService.Update(assay);
                    break;
                }
            }
            return RedirectToAction("Index");
        }
    }
}