using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Terres.Core.Entities.Database;
using Terres.Core.Services;

namespace Terres.Core.Interfaces
{
    public interface ICsvFactibilidadService : IGenericService<CSVFactibilidad>
    {
        Task<bool> ProcessCsvFactibilidadAsync(string filePath);
        List<CSVFactibilidad> GetAll();

    }
}
