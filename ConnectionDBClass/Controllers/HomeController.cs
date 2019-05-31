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

            da.DTO.Model.ID = "1";

            da.DeleteNoEF(da.DTO);

            return View();
        }

        public ActionResult About(HOMEModel model)
        {
            ViewBag.Message = "Your application description page.";
            var da = new HOMEDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Model.DATA = model.DATA;

            da.InsertNoEF(da.DTO);

            return View();
        }

        public ActionResult Contact(HOMEModel model)
        {
            ViewBag.Message = "Your contact page.";
            var da = new HOMEDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Model.DATA = model.DATA;

            da.UpdateNoEF(da.DTO);
            return View();
        }
    }
}