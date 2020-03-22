using System;
using System.ComponentModel.DataAnnotations;
namespace adminlte.Models.Transferencias
{
    public class TransferenciasPropiasViewModel
    { 
        public string key { get; set; }
        [Display(Name = "Institución")]
        [Required]
        public string institucion{ get; set; }

        [Display(Name = "Cuenta origen")]
        [Required]
        public string cuentaDesde { get; set; }
        [Required]
        [Display(Name = "Cuenta destino")]
        public string cuentaHasta { get; set; }
        [Required]
        [Display(Name = "Valor a transferir")]
        public double valor { get; set; }

        [Display(Name = "Mensaje")]
        public string mensaje { get; set; }

        [Display(Name = "Transacción")]
        public string transaccion { get; set; }

        [Display(Name = "Comisión")]
        public string comision { get; set; }

        [Display(Name = "Correo (opcional)")]
        public string correo { get; set; }

        [Display(Name = "cliente")]
        public string cliente { get; set; }
    }

    public class TransferenciasInternasViewModel
    {
        public string key { get; set; }

        [Display(Name = "Cuenta origen")]
        public string cuentaDesde { get; set; }

        [Display(Name = "Cuenta destino")]
        public string cuentaHasta { get; set; }

        [Display(Name = "Valor a transferir")]
        public double valor { get; set; }

        [Display(Name = "Mensaje")]
        public string mensaje { get; set; }

        [Display(Name = "Transacción")]
        public string transaccion { get; set; }

        [Display(Name = "Comisión")]
        public string comision { get; set; }

        [Display(Name = "Correo (opcional)")]
        public string correo { get; set; }


        [Display(Name = "cliente")]
        public string cliente { get; set; }
    }
}