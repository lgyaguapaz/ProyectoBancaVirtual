using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

//using System.Web.Mvc.Html;
using Newtonsoft.Json;
using adminlte.Models;

namespace adminlte
{
    public class Util
    {
        
        public async Task<CoutryIPModel> ValidarPais(string ip)
        {
            CoutryIPModel EmpInfo = new CoutryIPModel();
            string Baseurl = "http://api.ipstack.com/190.57.167.74?access_key=408a693022890908eb9520ff1aa56a58&format=1";

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(client.BaseAddress);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<CoutryIPModel>(EmpResponse);

                }
                //returning the employee list to view  
                return EmpInfo;
            }
        }
       

    }
}