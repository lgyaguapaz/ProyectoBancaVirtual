using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Mvc;
using adminlte.Models.Cartera;
using CanaNegocio;

namespace adminlte.Controllers
{
    [Authorize]
    public class CarteraController : Controller
    {
        // GET: Cartera
        public ActionResult Index()
        {
            DataSet ds = new DataSet();
            if (User.Identity.IsAuthenticated)
            {
                ds.Tables.Add(NCartera.ObtenerCreditos(User.Identity.Name));
            }
            return View(ds);
        }
        [HttpPost]
        public ActionResult Transacciones(CreditoViewModel credito)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            DataSet ds = new DataSet();
            if (User.Identity.IsAuthenticated)
            {
                ds.Tables.Add(NCartera.ObtnerTransacciones(User.Identity.Name, credito.operacion));
                
            }
            ViewBag.ds = ds;

            return View(credito);
        }


    }
}
