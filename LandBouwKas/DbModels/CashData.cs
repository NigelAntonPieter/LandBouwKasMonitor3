using LandBouwKas.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandBouwKas.Model
{
    public class CashData
    {
         public int Id { get; set; }
        public DateTime FetchDate { get; set; }
        public DateTime Date { get; set; }

        public string JSONDATA { get; set; }

        public Root ToRoot ()
        {
            // noodzakelijk om de JSON-gegevens bruikbaar te maken
            Root parsed = JsonConvert.DeserializeObject<Root>(JSONDATA); 
            return parsed;
        }
        
    }
}
