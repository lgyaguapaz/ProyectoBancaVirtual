using System;
using System.Collections.Generic;

using System.Data;
using System.Web.Mvc;
using adminlte.Models.DepositosPlazo;
using CanaNegocio;
namespace adminlte.Controllers
{
    public class DepositosplazoController : Controller
    {
        // GET: Depositosplazo
        public ActionResult Index()
        {
            DataTable ds = new DataTable();
            if (User.Identity.IsAuthenticated)
            {
                ds = NPlazoFijo.ObtenerPlazoFijo(User.Identity.Name);
            }
            List<DepositosPlazoViewModel> lstPerson = new List<DepositosPlazoViewModel>(); // Creating a list of Person objects
            foreach (DataRow dr in ds.Rows)
            {
                DepositosPlazoViewModel p = new DepositosPlazoViewModel(); // Creating a Person object

                // Setting the column values
                p.operacion = dr[0].ToString();
                p.oficial = dr[1].ToString();
                p.fechacreacion = Convert.ToDateTime(dr[2].ToString());
                p.fechavencimiento = Convert.ToDateTime(dr[3].ToString());
                p.tipo = dr[4].ToString();
                p.valor = Convert.ToDouble(dr[5].ToString());
                p.estado = dr[6].ToString();
                p.cliente = dr[7].ToString();
                p.tasa = Convert.ToDouble(dr[8].ToString());
                p.interes= Convert.ToDouble(dr[9].ToString());
                p.plazo = Convert.ToInt32(dr[10].ToString());
                p.key = dr[11].ToString();
                lstPerson.Add(p); // Populating the list
            }
            return View(lstPerson);
            
        }


        [HttpPost]
        public ActionResult Detalle(DepositosPlazoViewModel plazofijo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            //DataSet ds = new DataSet();
            //if (User.Identity.IsAuthenticated)
            //{
            //    ds.Tables.Add(NCartera.ObtnerTransacciones(User.Identity.Name, plazofijo.operacion));
            //}
            //ViewBag.ds = ds;

            return View(plazofijo);
        }



    }
}
