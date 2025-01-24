using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terres.Core.Entities.Database
{


    public class JojmaUser : IdentityUser
    {
        public JojmaUser()
        {
            Lotes = new HashSet<Lote>();
        }
        public string? Name { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
    }



}