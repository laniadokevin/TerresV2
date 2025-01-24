using Terres.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terres.Core.Interfaces;
using Terres.Core.Entities.Database;

namespace Terres.Data.OLD.Repositories
{
    public class LoteRepository : ILoteRepository
    {
        private readonly JojmaDbContext _context;
        private readonly LoteRepository _loteRepository;

        public LoteRepository(JojmaDbContext context)
        {
            _context = context;

        }

        public Lote SaveLote(Lote lote)
        {
            if (lote.Id > 0)
            {
                var lotedb = _context.Lote.Where(x => x.Id == lote.Id).FirstOrDefault();

                lotedb.SMP = lote.SMP;

                _context.SaveChanges();
            }
            else
            {
                _context.Lote.Add(lote);
                _context.SaveChanges();
            }

            return lote;
        }
        public List<TipoLote> GetAllTipoLotes()
        {
            var tipoLotes = _context.TipoLote.ToList();

            return tipoLotes;
        }
        public List<Lote> GetAllLotes()
        {
            var lotes = _context.Lote.ToList();

            return lotes;
        }
        public Lote GetLoteById(int id)
        {
            var lote = _context.Lote.Where(l => l.Id == id).Include(x => x.TipoLote).FirstOrDefault();

            return lote;
        }
        public BaseLotes GetLoteDetalle(string smp)
        {
            return _context.BaseLotes
    .Where(x => x.SMP == smp)
    .FirstOrDefault();
        }

        public List<Lote> GetAllLotesByFilters(string searchText, int tipoLoteId)
        {
            var query = _context.Lote.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(l => l.Direccion.Contains(searchText));
            }

            if (tipoLoteId > 0)
            {
                query = query.Where(l => l.TipoLoteId == tipoLoteId);
            }

            return query.ToList();
        }
        public List<Lote> GetAllLotes(string? userId)
        {
            List<Lote> lotes = new List<Lote>();

            if (userId != null)
            {
                lotes = _context.Lote.Where(l => l.UserId.ToString() == userId).ToList();
            }

            return lotes;
        }

    }
}
