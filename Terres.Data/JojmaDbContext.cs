using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Terres.Core.Entities.Database;

namespace Terres.Data
{
    public class JojmaDbContext : IdentityDbContext<JojmaUser>
    {
        public JojmaDbContext(DbContextOptions<JojmaDbContext> options) : base(options) { }

        public virtual DbSet<BaseLotes> BaseLotes { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<TipoLote> TipoLote { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public DbSet<CSVFactibilidad> CsvGeneratedClasses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llamar a la configuración base para Identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(login => new { login.LoginProvider, login.ProviderKey });
            
			modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.Id); // Define la clave primaria
                entity.HasOne(d => d.TipoLote) // Relación con TipoLote
                      .WithMany()
                      .HasForeignKey(d => d.TipoLoteId);
            });

			modelBuilder.Entity<BaseLotes>(entity =>
			{
				entity.HasNoKey(); // Esta entidad no tiene clave primaria

				// Configuración de mapeo de tabla
				entity.ToTable("BaseLotes");

				// Configuración de columnas (propiedades)
				entity.Property(e => e.SMP)
					.HasColumnName("SMP")
					.HasMaxLength(255);

				entity.Property(e => e.SM)
					.HasColumnName("SM")
					.HasMaxLength(255);

				entity.Property(e => e.Barrio)
					.HasColumnName("Barrio")
					.HasMaxLength(255);

				entity.Property(e => e.Direccion)
					.HasColumnName("Direccion")
					.HasMaxLength(255);

				entity.Property(e => e.Frente)
					.HasColumnName("Frente")
					.HasColumnType("float");

				entity.Property(e => e.Fondo)
					.HasColumnName("Fondo")
					.HasColumnType("float");

				entity.Property(e => e.SuperficieEdificada)
					.HasColumnName("Superficie edificada")
					.HasColumnType("float");

				entity.Property(e => e.SuperficieParcela)
					.HasColumnName("Superficie parcela")
					.HasColumnType("float");

				entity.Property(e => e.ValorIncidenciaDeSuelo)
					.HasColumnName("Valor incidencia de suelo")
					.HasColumnType("float");

				entity.Property(e => e.AlicuotaDiferencialPorZona)
					.HasColumnName("Alicuota diferencial por zona")
					.HasColumnType("float");

				entity.Property(e => e.LineaInterna)
					.HasColumnName("Linea interna")
					.HasColumnType("float");

				entity.Property(e => e.SEdificableB)
					.HasColumnName("S#Edificable - B")
					.HasMaxLength(255);

				entity.Property(e => e.SEdificableCP)
					.HasColumnName("S#Edificable - CP")
					.HasMaxLength(255);

				entity.Property(e => e.SEdificableR1)
					.HasColumnName("S#Edificable - R1")
					.HasMaxLength(255);

				entity.Property(e => e.SEdificableR2)
					.HasColumnName("S#Edificable - R2")
					.HasMaxLength(255);

				entity.Property(e => e.PosicionManzana)
					.HasColumnName("Posicion manzana")
					.HasMaxLength(255);

				entity.Property(e => e.Unidad)
					.HasColumnName("Unidad")
					.HasMaxLength(255);

				entity.Property(e => e.Altura)
					.HasColumnName("Altura")
					.HasColumnType("float");

				entity.Property(e => e.AreaEspecialAgrupada)
					.HasColumnName("Area especial agrupada")
					.HasMaxLength(255);

				entity.Property(e => e.AreaEspecialIndividualizada)
					.HasColumnName("Area especial individualizada")
					.HasMaxLength(255);

				entity.Property(e => e.DistritoSegunAE)
					.HasColumnName("Distrito segun AE")
					.HasMaxLength(255);

				entity.Property(e => e.AEFOT)
					.HasColumnName("AE FOT")
					.HasColumnType("float");

				entity.Property(e => e.Mixtura)
					.HasColumnName("Mixtura")
					.HasMaxLength(255);

				entity.Property(e => e.DistritoCPU)
					.HasColumnName("Distrito CPU")
					.HasMaxLength(255);

				entity.Property(e => e.AlturaCPU)
					.HasColumnName("Altura CPU")
					.HasColumnType("float");

				entity.Property(e => e.FOT)
					.HasColumnName("FOT")
					.HasMaxLength(255);

				entity.Property(e => e.LineaEspecialParticularizada)
					.HasColumnName("Linea especial particularizada")
					.HasMaxLength(255);

				entity.Property(e => e.TipoManzana)
					.HasColumnName("Tipo manzana")
					.HasMaxLength(255);

				entity.Property(e => e.Catalogacion)
					.HasColumnName("Catalogacion")
					.HasMaxLength(255);

				entity.Property(e => e.Proteccion)
					.HasColumnName("Proteccion")
					.HasMaxLength(255);

				entity.Property(e => e.Estado)
					.HasColumnName("Estado")
					.HasMaxLength(255);

				entity.Property(e => e.Ley3056EdificioAnteriorA1941)
					.HasColumnName("Ley3056EdificioAnteriorA1941")
					.HasMaxLength(255);

				entity.Property(e => e.Consolidado)
					.HasColumnName("Consolidado")
					.HasMaxLength(255);

				entity.Property(e => e.PisosRegistrados)
					.HasColumnName("Pisos registrados")
					.HasColumnType("float");

				entity.Property(e => e.CantidadDeUnidades)
					.HasColumnName("Cantidad de unidades")
					.HasColumnType("float");

				entity.Property(e => e.CuartilMin)
					.HasColumnName("Cuartil - Min")
					.HasColumnType("float");

				entity.Property(e => e.Cuartil1)
					.HasColumnName("Cuartil - 1")
					.HasColumnType("float");

				entity.Property(e => e.Cuartil2)
					.HasColumnName("Cuartil - 2")
					.HasColumnType("float");

				entity.Property(e => e.Cuartil3)
					.HasColumnName("Cuartil - 3")
					.HasColumnType("float");

				entity.Property(e => e.Cuartil4)
					.HasColumnName("Cuartil - 4")
					.HasColumnType("float");

				entity.Property(e => e.CuartilLote)
					.HasColumnName("Cuartil - Lote")
					.HasMaxLength(255);

				entity.Property(e => e.Centroide)
					.HasColumnName("centroide")
					.HasMaxLength(255);

				entity.Property(e => e.SmpAnterior)
					.HasColumnName("smp_anterior")
					.HasMaxLength(255);

				entity.Property(e => e.SmpSiguiente)
					.HasColumnName("smp_siguiente")
					.HasMaxLength(255);

				entity.Property(e => e.PdaMatriz)
					.HasColumnName("pdamatriz")
					.HasColumnType("float");

				entity.Property(e => e.SuperficieTotal)
					.HasColumnName("superficie_total")
					.HasColumnType("float");

				entity.Property(e => e.SuperficieCubierta)
					.HasColumnName("superficie_cubierta")
					.HasColumnType("float");

				entity.Property(e => e.FrenteSegunMBA)
					.HasColumnName("frente segun MBA")
					.HasColumnType("float");

				entity.Property(e => e.FondoSegunMBA)
					.HasColumnName("fondo segun MBA")
					.HasColumnType("float");

				entity.Property(e => e.PropiedadHorizontal)
					.HasColumnName("propiedad_horizontal")
					.HasMaxLength(255);

				entity.Property(e => e.PisosBajoRasante)
					.HasColumnName("pisos_bajo_rasante")
					.HasColumnType("float");

				entity.Property(e => e.PisosSobreRasante)
					.HasColumnName("pisos_sobre_rasante")
					.HasColumnType("float");

				entity.Property(e => e.UnidadesFuncionales)
					.HasColumnName("unidades_funcionales")
					.HasColumnType("float");

				entity.Property(e => e.CantidadPuertas)
					.HasColumnName("cantidad_puertas")
					.HasColumnType("float");
			});
			
			modelBuilder.Entity<TipoLote>(entity =>
            {
                entity.HasKey(p => p.Id); // Define la clave primaria
            });
            
			modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.LogID); // Define la clave primaria
                entity.ToTable("Log"); // Nombre de la tabla
            });
			
			modelBuilder.Entity<CSVFactibilidad>(entity =>
            {
				entity.HasKey(c=>c.Id);
                entity.ToTable("CSVFactibilidad"); 
            });

        }
    }
}
