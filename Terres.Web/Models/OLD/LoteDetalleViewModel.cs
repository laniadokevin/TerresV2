using Terres.Core.Entities.Database;

namespace Terres.Web.Models.OLD
{
    public class LoteDetalleViewModel
    {
        public Lote Lote { get; set; }
        public BaseLotes DetalleLote { get; set; }
        public CSVFactibilidad CSVFactibilidad { get; set; }
    }

}
