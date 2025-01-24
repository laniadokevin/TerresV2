using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Terres.Data.Migrations
{
    /// <inheritdoc />
    public partial class CSVFactibilidadCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CSVFactibilidad",
                columns: table => new
                {
                    DIR1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIR13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MVT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MVC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MVE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ALICUOTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INCIDENCIA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EDIFADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTRIBUCIONUVA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTRIBUCIONUSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UVA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CATALOGACION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROTECCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEY_3056 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARRIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARRIO2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARRIO3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIPO_MANZANA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FRENTE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FRENTE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FONDO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FONDO1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUPEDIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_ZONFI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_FOT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_ALTURA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_CAPVEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CU_UEDIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CU_MIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CU_ALTURA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CU_PTIPO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CU_PR1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CU_PR2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EXTENSION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA1_TITULO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA1_PISOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA1_CUB_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA1_EXP_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA1_ACUM_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA1_CUB_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA1_EXP_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA1_ACUM_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA2_TITULO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA2_PISOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA2_CUB_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA2_EXP_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA2_ACUM_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA2_CUB_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA2_EXP_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA2_ACUM_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA3_TITULO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA3_PISOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA3_CUB_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA3_EXP_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA3_ACUM_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA3_CUB_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA3_EXP_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA3_ACUM_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA4_TITULO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA4_PISOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA4_CUB_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA4_EXP_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA4_ACUM_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA4_CUB_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA4_EXP_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA4_ACUM_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA5_TITULO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA5_PISOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA5_CUB_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA5_EXP_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA5_ACUM_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA5_CUB_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA5_EXP_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA5_ACUM_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA6_TITULO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA6_PISOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA6_CUB_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA6_EXP_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA6_ACUM_V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA6_CUB_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA6_EXP_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILA6_ACUM_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LI = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CSVFactibilidad");
        }
    }
}
