using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminlte.Models.Cartera
{
    public class CarteraViewModels
    {
    }
    public class CreditoViewModel
    {
        public string key { get; set; }
        public string operacion { get; set; }
        public string producto { get; set; }
        public string estado { get; set; }
        public string oficial { get; set; }
        public int plazo { get; set; }      
        public double saldo { get; set; }
        public double ValorVencido { get; set; }
        public DateTime otorgamiento { get; set; }
    }

    public class CreditoTranViewModel
    {
        public string tipo { get; set; }
        public string credito { get; set; }
        public double valor { get; set; }
        public DateTime fecha { get; set; }
        public double saldo{ get; set; }
        public int cuota { get; set; }
    }
}