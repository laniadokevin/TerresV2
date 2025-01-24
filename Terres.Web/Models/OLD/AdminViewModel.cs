using Terres.Core.OLD.Entities.ViewModel.Lotes;

namespace Terres.Web.Models.OLD
{
    public class AdminViewModel
    {
        public List<LoteDto> Lotes { get; set; }
        public List<TipoLoteDto> TiposLote { get; set; }
    }
}
