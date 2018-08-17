using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RegistroController : Controller
    {
        ConexionUsuariosEntities db = new ConexionUsuariosEntities();
        // GET: Registro
        public ActionResult SetDataInDataBase()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetDataInDataBase(LoginPanel model)
        {
            LoginPanel tbl = new LoginPanel();
            tbl.Username = model.Username;
            tbl.Password = model.Password;
            db.LoginPanels.Add(tbl);
            db.SaveChanges();
            return View();
        }
        public ActionResult ShowDataBaseForUser()
        {
            var item = db.LoginPanels.ToList();
            return View(item);
        }
        public ActionResult Borrar(int id)
        {
          var item = db.LoginPanels.Where(x => x.ID == id).First();
          db.LoginPanels.Remove(item);
            db.SaveChanges();
            var item2 = db.LoginPanels.ToList();
            return View("ShowDataBaseForUser", item2);
        }
        public ActionResult Editar(int id)
        {
           var item = db.LoginPanels.Where(x => x.ID == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Editar(LoginPanel model)
        {
            var item = db.LoginPanels.Where(x => x.ID == model.ID).First();
            item.Username = model.Username;
            item.Password = model.Password;
            db.SaveChanges();
            return View();
        }
    }
}