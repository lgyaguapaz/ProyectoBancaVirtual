using System;
using System.ComponentModel.DataAnnotations;

namespace adminlte.Models.DepositosPlazo
{
    

    public class DepositosPlazoViewModel
    {
        public string key { get; set; }
        [Display(Name = "Operación")]
        public string operacion { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [Display(Name = "Oficial")]
        public string oficial { get; set; }
        [Display(Name = "Tipo Operación")]
        public string tipo { get; set; }
        [Display(Name = "Plazo")]
        public int plazo { get; set; }
        [Display(Name = "Monto")]
        public double valor { get; set; }
        [Display(Name = "Tasa de Interés")]
        public double tasa { get; set; }
        [Display(Name = "Interes pactado")]
        public double interes { get; set; }
        [Display(Name = "Fecha Vencimiento")]
        public DateTime fechavencimiento { get; set; }
        [Display(Name = "Fecha Apertura")]
        public DateTime fechacreacion { get; set; }
        [Display(Name = "cliente")]
        public string cliente { get; set; }
    }
}