using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terres.Core.OLD.Entities.ViewModel.Lotes;

namespace Terres.Core.Interfaces
{
    public interface IUsigNormalizador
    {
        /// <summary>
        /// Normaliza una dirección utilizando la API de USIG.
        /// </summary>
        /// <param name="direccion">Dirección a normalizar.</param>
        /// <returns>La dirección normalizada o un mensaje de error.</returns>
        Task<string> NormalizarDireccionAsync(string direccion);

        /// <summary>
        /// Normaliza una dirección utilizando la API de USIG.
        /// </summary>
        /// <param name="direccion">Dirección a normalizar.</param>
        /// <returns>La dirección normalizada o un mensaje de error.</returns>
        Task<DireccionBA> ObtenerCoordenadasAsync(LoteBA lote);
        
		/// <summary>
		/// Normaliza una dirección utilizando la API de USIG.
		/// </summary>
		/// <param name="direccion">Dirección a normalizar.</param>
		/// <returns>La dirección normalizada o un mensaje de error.</returns>
		Task<DireccionBA> ObtenerSMPAsync(LoteBA lote);
		/// <summary>
		/// Normaliza una dirección utilizando la API de USIG.
		/// </summary>
		/// <param name="direccion">Dirección a normalizar.</param>
		/// <returns>La dirección normalizada o un mensaje de error.</returns>
		string NormalizarDireccion(string direccion);

		/// <summary>
		/// Normaliza una dirección utilizando la API de USIG.
		/// </summary>
		/// <param name="direccion">Dirección a normalizar.</param>
		/// <returns>La dirección normalizada o un mensaje de error.</returns>
		DireccionBA ObtenerCoordenadas(LoteBA lote);

		/// <summary>
		/// Normaliza una dirección utilizando la API de USIG.
		/// </summary>
		/// <param name="direccion">Dirección a normalizar.</param>
		/// <returns>La dirección normalizada o un mensaje de error.</returns>
		DireccionBA ObtenerSMP(LoteBA lote);
	}
}
