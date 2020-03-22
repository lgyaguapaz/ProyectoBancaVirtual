using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Mvc;
using adminlte.Models.Ahorros;
using CanaNegocio;

namespace adminlte.Controllers
{
    [Authorize]
    public class AhorrosController : Controller
    {
        
        public ActionResult All()
        {
            DataSet ds = new DataSet();
            if (User.Identity.IsAuthenticated)
            {
                ds.Tables.Add(NCuentas.ObtenerCuentas(User.Identity.Name));   
            }
            return View(ds);
        }

        
        [HttpGet]
        public ActionResult Accounttransactions()
        {
            
            CuentasData obj = new CuentasData();
            List<DropdownCuentasModel> objcuentas = new List<DropdownCuentasModel>();
            objcuentas = obj.CuentasList(User.Identity.Name);
            SelectList objlistofcountrytobind = new SelectList(objcuentas, "ID", "Name", 0);
            ViewBag.CuentasDropDown = objlistofcountrytobind;                      
            return View(new BuscarTransaccionesModel { Cuenta =objcuentas ,CuentaSeleccionada = null, FechaFin = DateTime.Now ,FechaInicio= DateTime.Now});// SelectedProvider = "PhoneCode", ReturnUrl = returnUrl });

        }

        [HttpPost]
        public ActionResult Accounttransactions(BuscarTransaccionesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            DateTime FechaIni = Convert.ToDateTime(model.FechaInicio);
            DateTime FechaFin = Convert.ToDateTime(model.FechaFin);

            DataSet ds = new DataSet();
            if (User.Identity.IsAuthenticated)
            {
                ds.Tables.Add(NCuentas.ObtnerTransaccionesFecha(User.Identity.Name, model.CuentaSeleccionada, FechaIni, FechaFin));
            }
            CuentasData obj = new CuentasData();
            List<DropdownCuentasModel> objcuentas = new List<DropdownCuentasModel>();
            objcuentas = obj.CuentasList(User.Identity.Name);
            SelectList objlistofcountrytobind = new SelectList(objcuentas, "ID", "Name", 0);
            ViewBag.CuentasDropDown = objlistofcountrytobind;

            ViewBag.ds = ds;
            return View("Accounttransactions", new BuscarTransaccionesModel { CuentaSeleccionada = model.CuentaSeleccionada, FechaFin = model.FechaFin, FechaInicio = model.FechaInicio});

        }
    }
}