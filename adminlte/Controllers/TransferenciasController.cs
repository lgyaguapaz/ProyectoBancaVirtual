using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using adminlte.Models.Transferencias;
using adminlte.Models.Ahorros;
using CanaNegocio;

using Newtonsoft.Json;

namespace adminlte.Controllers
{
    [Authorize]
    public class TransferenciasController : Controller
    {
        
        public ActionResult CuentasPropias()
        {
            CuentasData obj = new CuentasData();
            List<DropdownCuentasModel> objcuentas = new List<DropdownCuentasModel>();
            objcuentas = obj.CuentasList(User.Identity.Name);
            ViewBag.CuentasDropDown = objcuentas;
            return View();
        }

        [HttpPost]
        public ActionResult CuentasPropias(TransferenciasPropiasViewModel model)
        {
            
            CuentasData obj = new CuentasData();
            List<DropdownCuentasModel> objcuentas = new List<DropdownCuentasModel>();
            objcuentas = obj.CuentasList(User.Identity.Name);
            ViewBag.CuentasDropDown = objcuentas;
            

            return RedirectToAction("DetalleTransferenciaPropia", model);

        }


        //[HttpGet]
        //public ActionResult ConfirmarTransferenciaPropias(TransferenciasPropiasViewModel model)
        //{

        //    return RedirectToAction("DetalleTransferenciaPropia", model);
        //}
        //[HttpPost]
        //public ActionResult ConfirmacionTransferenciaPropia(TransferenciasPropiasViewModel model)
        //{
            
        //    return RedirectToAction("DetalleTransferenciaPropia", model);
        //}
        [HttpGet]
        public ActionResult DetalleTransferenciaPropia(TransferenciasPropiasViewModel model)
        {
            
            return View(model);
        }


        public ActionResult CuentasInternas()
        {
            CuentasData obj = new CuentasData();
            List<DropdownCuentasModel> objcuentas = new List<DropdownCuentasModel>();
            objcuentas = obj.CuentasList(User.Identity.Name);
            return View();
        }

        [HttpPost]
        public ActionResult CuentasInternas(TransferenciasInternasViewModel model)
        {

            CuentasData obj = new CuentasData();
            List<DropdownCuentasModel> objcuentas = new List<DropdownCuentasModel>();
            objcuentas = obj.CuentasList(User.Identity.Name);
            return View();
        }

    }
}
