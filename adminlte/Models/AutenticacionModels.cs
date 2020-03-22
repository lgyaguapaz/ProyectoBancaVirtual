using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace adminlte.Models
{
    public class SendOTPModel
    {
        [Required]
        string codigo { get; set; }
    }
}