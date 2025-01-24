using Terres.Core.Entities.Database;

namespace Terres.Core.OLD.Entities.ViewModel.Lotes
{
    public class LoteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SMP { get; set; }
        public string Flujo { get; set; }
        public int TipoLoteId { get; set; }
        public TipoLote? TipoLote { get; set; }

        public BaseLotes? BaseLotes { get; set; }
    }
}
