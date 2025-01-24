using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terres.Core.Entities.Database;

namespace Terres.Core.Interfaces
{
    public interface ILoteRepository
	{
		Lote SaveLote(Lote lote);
		List<TipoLote> GetAllTipoLotes();
        List<Lote> GetAllLotes();
		Lote GetLoteById(int id);
        BaseLotes GetLoteDetalle(string smp);
        List<Lote> GetAllLotesByFilters(string searchText, int tipoLoteId);
		List<Lote> GetAllLotes(string? userId);
	}
}
