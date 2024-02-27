using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandBouwKas.Model
{
    internal class Geschiedenis
    {
        public int Id { get; set; }
        public Gewassen Gewassen { get; set; }   
        public DateTime Date {  get; set; }
        public int TemperatuurCelcius { get; set; }
        public int VochtigheidPercentage { get; set; }
        public int bodemGezondheidPH {  get; set; }
        public string ZonlichtIntensiteit { get; set; }
        public int ZonlichtUrenPerDag {get; set; }
        
    }
}
