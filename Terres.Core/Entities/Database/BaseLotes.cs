using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terres.Core.Entities.Database
{
    [Table("BaseLotes")]
    public class BaseLotes
    {
        [Column("SMP")]
        public string? SMP { get; set; }

        [Column("SM")]
        public string? SM { get; set; }

        [Column("Barrio")]
        public string? Barrio { get; set; }

        [Column("Direccion")]
        public string? Direccion { get; set; }

        [Column("Superficie edificada")]
        public float? SuperficieEdificada { get; set; }

        [Column("Superficie parcela")]
        public float? SuperficieParcela { get; set; }

        [Column("Frente")]
        public float? Frente { get; set; }

        [Column("Fondo")]
        public float? Fondo { get; set; }

        [Column("Valor incidencia de suelo")]
        public float? ValorIncidenciaDeSuelo { get; set; }

        [Column("Alicuota diferencial por zona")]
        public float? AlicuotaDiferencialPorZona { get; set; }

        [Column("Linea interna")]
        public float? LineaInterna { get; set; }

        [Column("S#Edificable - B")]
        public string? SEdificableB { get; set; }

        [Column("S#Edificable - CP")]
        public string? SEdificableCP { get; set; }

        [Column("S#Edificable - R1")]
        public string? SEdificableR1 { get; set; }

        [Column("S#Edificable - R2")]
        public string? SEdificableR2 { get; set; }

        [Column("Posicion manzana")]
        public string? PosicionManzana { get; set; }

        [Column("Unidad")]
        public string? Unidad { get; set; }

        [Column("Altura")]
        public float? Altura { get; set; }

        [Column("Area especial agrupada")]
        public string? AreaEspecialAgrupada { get; set; }

        [Column("Area especial individualizada")]
        public string? AreaEspecialIndividualizada { get; set; }

        [Column("Distrito segun AE")]
        public string? DistritoSegunAE { get; set; }

        [Column("AE FOT")]
        public float? AEFOT { get; set; }

        [Column("Mixtura")]
        public string? Mixtura { get; set; }

        [Column("Distrito CPU")]
        public string? DistritoCPU { get; set; }

        [Column("Altura CPU")]
        public float? AlturaCPU { get; set; }

        [Column("FOT")]
        public string? FOT { get; set; }

        [Column("Linea especial particularizada")]
        public string? LineaEspecialParticularizada { get; set; }

        [Column("Tipo manzana")]
        public string? TipoManzana { get; set; }

        [Column("Catalogacion")]
        public string? Catalogacion { get; set; }

        [Column("Proteccion")]
        public string? Proteccion { get; set; }

        [Column("Estado")]
        public string? Estado { get; set; }

        [Column("Ley3056EdificioAnteriorA1941")]
        public string? Ley3056EdificioAnteriorA1941 { get; set; }

        [Column("Consolidado")]
        public string? Consolidado { get; set; }

        [Column("Pisos registrados")]
        public float? PisosRegistrados { get; set; }

        [Column("Cantidad de unidades")]
        public float? CantidadDeUnidades { get; set; }

        [Column("Cuartil - Min")]
        public float? CuartilMin { get; set; }

        [Column("Cuartil - 1")]
        public float? Cuartil1 { get; set; }

        [Column("Cuartil - 2")]
        public float? Cuartil2 { get; set; }

        [Column("Cuartil - 3")]
        public float? Cuartil3 { get; set; }

        [Column("Cuartil - 4")]
        public float? Cuartil4 { get; set; }

        [Column("Cuartil - Lote")]
        public string? CuartilLote { get; set; }

        [Column("centroide")]
        public string? Centroide { get; set; }

        [Column("smp_anterior")]
        public string? SmpAnterior { get; set; }

        [Column("smp_siguiente")]
        public string? SmpSiguiente { get; set; }

        [Column("pdamatriz")]
        public float? PdaMatriz { get; set; }

        [Column("superficie_total")]
        public float? SuperficieTotal { get; set; }

        [Column("superficie_cubierta")]
        public float? SuperficieCubierta { get; set; }

        [Column("frente segun MBA")]
        public float? FrenteSegunMBA { get; set; }

        [Column("fondo segun MBA")]
        public float? FondoSegunMBA { get; set; }

        [Column("propiedad_horizontal")]
        public string? PropiedadHorizontal { get; set; }

        [Column("pisos_bajo_rasante")]
        public float? PisosBajoRasante { get; set; }

        [Column("pisos_sobre_rasante")]
        public float? PisosSobreRasante { get; set; }

        [Column("unidades_funcionales")]
        public float? UnidadesFuncionales { get; set; }

        [Column("cantidad_puertas")]
        public float? CantidadPuertas { get; set; }
    }
}
