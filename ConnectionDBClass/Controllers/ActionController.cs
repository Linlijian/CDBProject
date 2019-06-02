using DataAccess.ACTION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectionDBClass.Controllers
{
    public class ActionController : Controller
    {
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult Delete(ACTIONModel model)
        {

            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.Delete;
            da.Delete(da.DTO);
            
            return RedirectToAction("View");
        }

        public ActionResult SaveDelete(ACTIONModel model)
        {

            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.Delete;
            da.Delete(da.DTO);

            return RedirectToAction("View");
        }

        public ActionResult Update(ACTIONModel model)
        {
            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.GetByID;
            da.Select(da.DTO);

            return View(da.DTO.Model);
        }
        public ActionResult SaveUpdate(ACTIONModel model)
        {
            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Model.DATA = model.DATA;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.Update;
            da.Update(da.DTO);

            return RedirectToAction("Index");
        }

        public ActionResult Insert(ACTIONModel model)
        {
            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Model.DATA = model.DATA;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.Insert;
            da.Insert(da.DTO);

            return RedirectToAction("View");
        }
        public ActionResult SaveInsert(ACTIONModel model)
        {
            var da = new ACTIONDA();

            da.DTO.Model.ID = model.ID;
            da.DTO.Model.DATA = model.DATA;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.Insert;
            da.Insert(da.DTO);

            return RedirectToAction("View");
        }

        public ActionResult Search(ACTIONModel model)
        {
            var da = new ACTIONDA();

            //da.DTO.Model.ID = model.ID;
            //da.DTO.Model.DATA = model.DATA;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.GetAll;
            da.Select(da.DTO);
           
            return Json(new { data = da.DTO.Models }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchALl(ACTIONModel model)
        {
            var da = new ACTIONDA();

            //da.DTO.Model.ID = model.ID;
            //da.DTO.Model.DATA = model.DATA;
            da.DTO.Execute.ExecuteType = ACTIONExecuteType.GetAll;
            da.Select(da.DTO);

            return Json(new { data = da.DTO.Models }, JsonRequestBehavior.AllowGet);
        }


    }
}