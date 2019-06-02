using DataAccess.ACTION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectionDBClass.Controllers
{
    public class ActionEFController : Controller
    {
        public ActionResult Index()
        {
            var da = new ACTIONDA();

            //da.DTO.Model.ID = model.ID;
            //da.DTO.Model.DATA = model.DATA;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.GetAll;
            da.Select(da.DTO);

            return View(da.DTO.Models);
        }

       

        public ActionResult DeleteEF(ACTIONModel model)
        {
            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.DeleteEF;
            da.DeleteNoEF(da.DTO);

            return RedirectToAction("View");
        }

       

        public ActionResult UpdateEF(ACTIONModel model)
        {
            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.UpdateEF;
            da.UpdateNoEF(da.DTO);

            return RedirectToAction("View");
        }

        

        public ActionResult InsertEF(ACTIONModel model)
        {
            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Model.DATA = model.DATA;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.InsertEF;
            da.InsertNoEF(da.DTO);

            return RedirectToAction("View");
        }

        

        public ActionResult SearchEF(ACTIONModel model)
        {
            var da = new ACTIONDA();

            //da.DTO.Model.ID = model.ID;
            //da.DTO.Model.DATA = model.DATA;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.GetAllEF;
            da.SelectNoEF(da.DTO);

            return RedirectToAction("View");
        }
    }
}