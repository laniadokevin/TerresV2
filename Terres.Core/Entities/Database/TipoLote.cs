﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terres.Core.Entities.Database
{
    public class TipoLote
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
