using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terres.Core.Entities.Database;

namespace Terres.Core.OLD.Entities.ViewModel.Campus
{
    public class DashboardViewModel
    {
        public List<Lote> Lotes { get; set; }
        public List<TipoLote> TipoLotes { get; set; }
        public IdentityUser? User { get; set; }
    }
}