﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cargo
    {
        public string Id { get; set; }
        public string company_name { get; set; }
        public string company_id { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<object> Cargos { get; set; }
        public string paid_at { get; set; }
    }
}
