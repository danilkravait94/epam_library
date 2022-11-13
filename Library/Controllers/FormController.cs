using Library.BLL.BLLEntities;
using Library.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.Controllers
{
    /// <summary>
    /// controller for work with form
    /// </summary>
    public class FormController : Controller
    {
        /// <summary>
        /// Get method
        /// </summary>
        /// <returns>Form view</returns>
        private IFormService formService;
        private readonly IEnumerable<string> countrylist = new List<string> { "Ukraine", "Russia", "Germany", "China" };
        private readonly IEnumerable<string> smthlist = new List<string> { "smth1", "smth2", "smth3", "smth4" };
        /// <summary>
        /// no parameters constructor 
        /// </summary>
        public FormController(IFormService service)
        {
            formService = service;
        }
        
        /// <summary>
        /// Get a empty form 
        /// </summary>
        /// <returns> a cshtml form</returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Countrylist = countrylist;
            ViewBag.smthlist = smthlist;

            return View("Form");
        }
        /// <summary>
        /// Get a result 
        /// </summary>
        /// <param name="collection"> FormCollection</param>
        /// <returns>A cshtml result</returns>
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {

            if (ModelState.IsValid)
            {
                BLLForm form = new BLLForm
                {
                    Name = collection["name"],
                    Surname = collection["surname"],
                    Country = collection["Country"],
                    smths = smthlist.Where(smth => collection[smth] != null).ToList()
                };
                formService.Create(form);
                return View("Result", form);
            }
            else
            {
                ViewBag.Name = collection["name"];
                ViewBag.Surname = collection["surname"];
                ViewBag.Countrylist = countrylist;
                ViewBag.smthlist = smthlist;
                return View();
            }
        }
    }
}