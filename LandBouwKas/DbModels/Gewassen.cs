﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandBouwKas.Model
{
    public class Gewassen
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public Zone Zone { get; set; }
    }
}