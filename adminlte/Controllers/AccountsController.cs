using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adminlte.Models;

namespace adminlte.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        // GET: Tables
        public ActionResult All()
        {
            List<DetailsClientAccountsModel> list = new List<DetailsClientAccountsModel>();
            DetailsClientAccountsModel e = new DetailsClientAccountsModel()
            {
                cuenta = "123231",
                apertura = DateTime.Now,
                disponible = 500,
                saldo = 520,
                key = "8209842093",
                oficial = "Usuario 1",
                tipo = "Cuenta de Trabajo",
                ultimoMov = DateTime.Now,

            };
            list.Add(e);
            DetailsClientAccountsModel e1 = new DetailsClientAccountsModel()
            {
                cuenta = "999123",
                apertura = DateTime.Now,
                disponible = 4100,
                saldo = 4101,
                key = "123123",
                oficial = "Usuario 1",
                tipo = "Cuenta de Ahorros",
                ultimoMov = DateTime.Now,

            };
            list.Add(e1);
            ViewBag.Message = "Todos los moviemientos";
            return View(list);
        }

        public ActionResult Accountdetail(string data)
        {
            DetailsClientAccountsModel e1 = new DetailsClientAccountsModel()
            {
                cuenta = "999123",
                apertura = DateTime.Now,
                disponible = 4100,
                saldo = 4101,
                key = "123123",
                oficial = "Usuario 1",
                tipo = "Cuenta de Ahorros",
                ultimoMov = DateTime.Now,

            };
            
            ViewBag.Message = "Todos los moviemientos";
            
            return View(e1);
        }

        [HttpGet]
        public ActionResult Accounttransactions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Accounttransactions(string accountData)
        {
            AccountsData trans = new AccountsData();
            List<AccountTranModel> list = new List<AccountTranModel>();
            list = trans.getAccounTransTop( Convert.ToInt16(accountData));

            return View("Accounttransactions", list);
        }
        [HttpPost]
        public ActionResult Accounttransactionsdate(string accountData, string accountDataIni, string accountDataEnd)
        {
            string mensaje = "Your contact page... " + accountData.ToString() + "-" + accountDataIni.ToString();
            ViewBag.Message = mensaje;
            AccountsData trans = new AccountsData();
            List<AccountTranModel> list = new List<AccountTranModel>();
            list = trans.getAccounTransDate(Convert.ToDateTime(accountDataIni), Convert.ToDateTime(accountDataEnd));

            return View("Accounttransactions", list);
        }
    }
}