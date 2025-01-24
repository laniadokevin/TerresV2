using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terres.Core.Entities.Database
{
    public class Lote
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public int TipoLoteId { get; set; }
        public string? SMP { get; set; }
        public string? UserId { get; set; }
        public virtual TipoLote TipoLote { get; set; }
        public virtual JojmaUser User { get; set; }
    }
}
