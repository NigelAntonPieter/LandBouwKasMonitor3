using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandBouwKas.Model
{
    internal class GewassenVoedingstoffen
    {
        public int Id { get; set; }
        public Gewassen Gewassen { get; set; }
        public Voedingstoffen Voedingstoffen { get; set; }
    }
}
