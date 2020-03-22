using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace adminlte.Models.Ahorros
{
    public class DetailsClientAccountsModel
    {
        public string key { get; set; }
        public string cuenta { get; set; }
        public string tipo { get; set; }
        public string oficial { get; set; }
        public DateTime apertura { get; set; }
        public DateTime ultimoMov { get; set; }
        public double saldo { get; set; }
        public double disponible { get; set; }
    }

    public class BuscarTransaccionesModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }

        
        [DataType(DataType.Text)]
        [Display(Name = "Cuenta")]
        //public string Cuenta { get; set; }
        public  List<DropdownCuentasModel> Cuenta{ get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Cuenta")]
        //public string Cuenta { get; set; }
        public string CuentaSeleccionada { get; set; }

    }

    public class DropdownCuentasModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class AccountTranModel
    {
        public string tipo { get; set; }
        public string cuenta { get; set; }
        public double valor { get; set; }
        public DateTime fecha { get; set; }
        public int posteada { get; set; }
        public double disponible { get; set; }
    }

    public class ExistModel
    {
        public int ret { get; set; }
        public string mensaje { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }

    }
}