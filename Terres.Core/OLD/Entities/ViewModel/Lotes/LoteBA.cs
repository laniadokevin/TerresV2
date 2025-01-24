namespace Terres.Core.OLD.Entities.ViewModel.Lotes
{
    public class LoteBA
    {
        public string calle { get; set; }
        public int numero { get; set; }
        public string localidad { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
    }
    public class DireccionBA
    {
        public string Parcela { get; set; }
        public string Puerta { get; set; }
        public string Puerta_x { get; set; }
        public string Puerta_y { get; set; }
        public string Calle_alturas { get; set; }
        public string Esquina { get; set; }
        public string Metros_a_esquina { get; set; }
        public string Altura_par { get; set; }
        public string Altura_impar { get; set; }
    }
}
