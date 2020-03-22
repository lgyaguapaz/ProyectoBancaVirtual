using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminlte.Models.Cartera
{
    public class CarteraData
    {

        public List<CreditoViewModel> getAllCredito()
        {
            List<CreditoViewModel> list = new List<CreditoViewModel>();
            CreditoViewModel e = new CreditoViewModel()
            {
                operacion = "MICRO00001",
                otorgamiento = DateTime.Now,
                saldo = 1000,
                estado = "Vigente",
                oficial = "Oficial1",
                plazo= 48,
                producto = "Microcredito",
                ValorVencido=0

            };
            list.Add(e);
            CreditoViewModel e1 = new CreditoViewModel()
            {
                operacion = "COMERCIAL00001",
                otorgamiento = DateTime.Now,
                saldo = 34000,
                estado = "Vigente",
                oficial = "Oficial1",
                plazo = 24,
                producto = "Microcredito",
                ValorVencido = 0
            };
            list.Add(e1);
            return list;
        }
        public CreditoViewModel getCredito(string operacion)
        {
            
            CreditoViewModel e = new CreditoViewModel()
            {
                operacion = "MICRO00001",
                otorgamiento = DateTime.Now,
                saldo = 1000,
                estado = "Vigente",
                oficial = "Oficial1",
                plazo = 48,
                producto = "Microcredito",
                ValorVencido = 0

            };
            
            return e;
        }
        public List<CreditoTranViewModel> getTransCredito(string credito)
        {
            List<CreditoTranViewModel> list = new List<CreditoTranViewModel>();
            CreditoTranViewModel e = new CreditoTranViewModel()
            {
                credito = "MICRO00001",
                fecha = DateTime.Now,
                saldo = 1000,
                tipo= "Pago",
                valor = 80,
                cuota = 2

            };
            list.Add(e);
            CreditoTranViewModel e1 = new CreditoTranViewModel()
            {
                credito = "MICRO00001",
                fecha = DateTime.Now,
                saldo = 1000,
                tipo = "Pago",
                valor = 82,
                cuota = 3
            };
            list.Add(e1);
            return list;
        }
    }
}