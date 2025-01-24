using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Terres.Core.Entities.Database;
using Terres.Core.Interfaces;
using Terres.Data;
using Terres.Data.OLD.Repositories;
using Terres.Data.Services;

namespace Terres.Core.Interfaces
{

    public class CsvFactibilidadService :  GenericService<CSVFactibilidad>, ICsvFactibilidadService
    {
        private readonly JojmaDbContext _context;

        public CsvFactibilidadService(JojmaDbContext context): base(context) 
        {
            _context = context;
        }

        public List<CSVFactibilidad> GetAll()
        {
            return _context.CsvGeneratedClasses.ToList();
        }

        public async Task<bool> ProcessCsvFactibilidadAsync(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                }))
                {
                    var records = csv.GetRecords<CSVFactibilidad>().ToList();

                    _context.AddRange(records);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                // Manejar errores
                Console.WriteLine($"Error al procesar el CSV: {ex.Message}");
                return false;
            }
        }
    }

}
