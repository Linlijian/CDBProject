using DataAccess.HOME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectionDBClass.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var da = new HOMEDA();

            da.SelectNoEF(da.DTO);
            ViewBag.Data1 = da.DTO.Models[0].DATA;
            ViewBag.Data2 = da.DTO.Models[1].DATA;
            ViewBag.Id1 = da.DTO.Models[0].ID;
            ViewBag.Id2 = da.DTO.Models[1].ID;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}