using AutoMapper;
using Library.BLL.BLLEntities;
using Library.BLL.Interfaces;
using Library.Models;
using Library.Pading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.Controllers
{
    /// <summary>
    /// Review controller
    /// </summary>
    public class GuestController : Controller
    {
        private  IReviewService reviewService;

        /// <summary>
        /// no parameter constructor
        /// </summary>
        public GuestController(IReviewService service)
        {
            reviewService = service;
        }
        /// <summary>
        /// Get a view of reviews
        /// </summary>
        /// <returns>Reviews</returns>
        public ActionResult Index(int page = 1)
        {
            var reviews = reviewService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BLLReview, ReviewViewModel>()).CreateMapper();
            var reviewsViews = mapper.Map<IEnumerable<BLLReview>, List<ReviewViewModel>>(reviews);
            reviewsViews.Reverse();

            int pageSize = 2;
            IEnumerable<ReviewViewModel> reviewsperpage = reviewsViews.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = reviewsViews.Count() };
            IndexViewReview ivm = new IndexViewReview { PageInfo = pageInfo, Reviews = reviewsperpage };
            ReviewPagin pagin = new ReviewPagin() { IndexViewReview = ivm };
            return View(pagin);
        }

        /// <summary>
        /// Post a review
        /// </summary>
        /// <param name="collection">FormCollection</param>
        /// <returns> actionResult</returns>
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                ReviewViewModel reviewView = new ReviewViewModel(collection["Review.reviewName"], collection["Review.reviewText"], DateTime.Now);
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReviewViewModel,BLLAssay>()).CreateMapper();
                //var review = mapper.Map<ReviewViewModel, BLLReview>(reviewView);
                reviewService.Create(new BLLReview(collection["Review.reviewName"], collection["Review.reviewText"], DateTime.Now));
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Chack that the name is used
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckIfExist(string name)
        {
            if(reviewService.CheckName(name)){
                return Json($"A user named {name} already exists.");
            }
            return Json(true);
        }
    }
}