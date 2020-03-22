using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class CoutryIPModel
    {
        string ip { get; set; }
        string type { get; set; }
        string continent_code { get; set; }
        string continent_name { get; set; }
        string country_code { get; set; }
        string country_name { get; set; }
        string region_code { get; set; }
        string region_name { get; set; }
        string city { get; set; }
    }
}