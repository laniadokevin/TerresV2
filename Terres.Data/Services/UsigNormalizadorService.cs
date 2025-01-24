using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Terres.Core.Interfaces;
using Terres.Core.OLD.Entities.ViewModel.Lotes;

public class UsigNormalizadorService : IUsigNormalizador
{
    private readonly HttpClient _httpClient;

    public UsigNormalizadorService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("https://servicios.usig.buenosaires.gob.ar/");
    }

    public async Task<string> NormalizarDireccionAsync(string direccion)
    {
        if (string.IsNullOrWhiteSpace(direccion))
            throw new ArgumentException("La dirección no puede estar vacía.", nameof(direccion));

        try
        {
            // Construir el endpoint y enviar la solicitud
            string endpoint = $"https://servicios.usig.buenosaires.gob.ar/normalizar/?direccion={Uri.EscapeDataString(direccion)}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            // Leer y deserializar la respuesta JSON
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var normalizacion = JsonSerializer.Deserialize<NormalizacionResponse>(jsonResponse);

            // Validar si se encontraron direcciones normalizadas
            if (normalizacion?.DireccionesNormalizadas != null && normalizacion.DireccionesNormalizadas.Any())
            {
                return normalizacion.DireccionesNormalizadas.First().Direccion; // Retorna la primera dirección normalizada
            }

            return "No se pudo normalizar la dirección.";
        }
        catch (Exception ex)
        {
            // Manejar errores y lanzar excepción hacia el controlador
            throw new Exception($"Error al normalizar la dirección: {ex.Message}", ex);
        }
    }

    public async Task<DireccionBA> ObtenerCoordenadasAsync(LoteBA lote)
    {
        if (string.IsNullOrWhiteSpace(lote.calle))
            throw new ArgumentException("La dirección no puede estar vacía.", nameof(lote.calle));

        try
        {
            // Construir el endpoint y enviar la solicitud
            string endpoint = $"https://datosabiertos-usig-apis.buenosaires.gob.ar/geocoder/2.2/geocoding?cod_calle=" + (lote.calle) + "&altura=" + (lote.numero);
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            // Leer y deserializar la respuesta JSON
            string jsonResponse = await response.Content.ReadAsStringAsync();

            var rtaDesarmada = DesarmarRespuesta(jsonResponse);

			var e = ObtenerSMP(rtaDesarmada);

            return e;

        }
        catch (Exception ex)
        {
            // Manejar errores y lanzar excepción hacia el controlador
            throw new Exception($"Error al normalizar la dirección: {ex.Message}", ex);
            return null;
        }
    }

    public async Task<DireccionBA> ObtenerSMPAsync(LoteBA l)
    {
        if (string.IsNullOrWhiteSpace(l.lat))
            throw new ArgumentException("La dirección no puede estar vacía.", nameof(l.calle));

        try
        {
            // Construir el endpoint y enviar la solicitud
            string endpoint = $"https://datosabiertos-usig-apis.buenosaires.gob.ar/geocoder/2.2/reversegeocoding?x=" + l.lat + "&y=" + l.lon;
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            // Leer y deserializar la respuesta JSON
            string jsonResponse = await response.Content.ReadAsStringAsync();
            
            return DesarmarRespuestalarga(jsonResponse);

        }
        catch (Exception ex)
        {
            // Manejar errores y lanzar excepción hacia el controlador
            throw new Exception($"Error al normalizar la dirección: {ex.Message}", ex);
            return null;
        }
    }

	public string NormalizarDireccion(string direccion)
	{
		if (string.IsNullOrWhiteSpace(direccion))
			throw new ArgumentException("La dirección no puede estar vacía.", nameof(direccion));

		try
		{
			// Construir el endpoint y enviar la solicitud
			string endpoint = $"https://servicios.usig.buenosaires.gob.ar/normalizar/?direccion={Uri.EscapeDataString(direccion)}";
			HttpResponseMessage response = _httpClient.GetAsync(endpoint).Result;
			response.EnsureSuccessStatusCode();

			// Leer y deserializar la respuesta JSON
			string jsonResponse = response.Content.ReadAsStringAsync().Result;
			var normalizacion = JsonSerializer.Deserialize<NormalizacionResponse>(jsonResponse);

			// Validar si se encontraron direcciones normalizadas
			if (normalizacion?.DireccionesNormalizadas != null && normalizacion.DireccionesNormalizadas.Any())
			{
				return normalizacion.DireccionesNormalizadas.First().Direccion; // Retorna la primera dirección normalizada
			}

			return "No se pudo normalizar la dirección.";
		}
		catch (Exception ex)
		{
			// Manejar errores y lanzar excepción hacia el controlador
			throw new Exception($"Error al normalizar la dirección: {ex.Message}", ex);
		}
	}

	public DireccionBA ObtenerCoordenadas(LoteBA lote)
	{
		if (string.IsNullOrWhiteSpace(lote.calle))
			throw new ArgumentException("La dirección no puede estar vacía.", nameof(lote.calle));

		try
		{
			// Construir el endpoint y enviar la solicitud
			string endpoint = $"https://datosabiertos-usig-apis.buenosaires.gob.ar/geocoder/2.2/geocoding?cod_calle=" + (lote.calle) + "&altura=" + (lote.numero);
			HttpResponseMessage response =  _httpClient.GetAsync(endpoint).Result;
			response.EnsureSuccessStatusCode();

			// Leer y deserializar la respuesta JSON
			string jsonResponse = response.Content.ReadAsStringAsync().Result;

			var rtaDesarmada = DesarmarRespuesta(jsonResponse);

			var e =  ObtenerSMP(rtaDesarmada);

			return e;

		}
		catch (Exception ex)
		{
			// Manejar errores y lanzar excepción hacia el controlador
			throw new Exception($"Error al normalizar la dirección: {ex.Message}", ex);
			return null;
		}
	}

	public DireccionBA ObtenerSMP(LoteBA l)
	{
		if (string.IsNullOrWhiteSpace(l.lat))
			throw new ArgumentException("La dirección no puede estar vacía.", nameof(l.calle));

		try
		{
			// Construir el endpoint y enviar la solicitud
			string endpoint = $"https://datosabiertos-usig-apis.buenosaires.gob.ar/geocoder/2.2/reversegeocoding?x=" + l.lat + "&y=" + l.lon;
			HttpResponseMessage response = _httpClient.GetAsync(endpoint).Result;
			response.EnsureSuccessStatusCode();

			// Leer y deserializar la respuesta JSON
			string jsonResponse = response.Content.ReadAsStringAsync().Result;

			return DesarmarRespuestalarga(jsonResponse);

		}
		catch (Exception ex)
		{
			// Manejar errores y lanzar excepción hacia el controlador
			throw new Exception($"Error al normalizar la dirección: {ex.Message}", ex);
			return null;
		}
	}
	static LoteBA DesarmarRespuesta(string respuesta)
    {
        // Eliminar los paréntesis envolventes
        respuesta = respuesta.Trim('(', ')');

        // Parsear usando Newtonsoft.Json
        var jsonObj = JObject.Parse(respuesta);
        double x = jsonObj["x"]?.Value<double>() ?? 0;
        double y = jsonObj["y"]?.Value<double>() ?? 0;
        LoteBA a = new LoteBA();
		a.lat = x.ToString().Replace(",", ".");
		a.lon = y.ToString().Replace(",", ".");
		return a;
    }
    static DireccionBA DesarmarRespuestalarga(string respuesta)
    {
        // Eliminar los paréntesis envolventes
        respuesta = respuesta.Trim('(', ')');

        // Parsear usando Newtonsoft.Json
        var jsonObj = JObject.Parse(respuesta);
        string parcela= jsonObj["parcela"]?.Value<string>() ?? "";
        string puerta= jsonObj["puerta"]?.Value<string>() ?? "";
        string puerta_x= jsonObj["puerta_x"]?.Value<string>() ?? "";
        string puerta_y= jsonObj["puerta_y"]?.Value<string>() ?? "";
        string calle_alturas= jsonObj["calle_alturas"]?.Value<string>() ?? "";
        string esquina= jsonObj["esquina"]?.Value<string>() ?? "";
        string metros_a_esquina= jsonObj["metros_a_esquina"]?.Value<string>() ?? "";
        string altura_par= jsonObj["altura_par"]?.Value<string>() ?? "";
        string altura_impar = jsonObj["altura_impar"]?.Value<string>() ?? "";
        DireccionBA a = new DireccionBA();
        
        a.Parcela =parcela;
        a.Puerta =puerta;
        a.Puerta_x =puerta_x;
        a.Puerta_y =puerta_y;
        a.Calle_alturas =calle_alturas;
        a.Esquina =esquina;
        a.Metros_a_esquina =metros_a_esquina;
        a.Altura_par =altura_par;
        a.Altura_impar = altura_impar;
        return a;
    }


    // Clases para mapear la respuesta JSON
    public class NormalizacionResponse
    {
        [JsonPropertyName("direccionesNormalizadas")]
        public DireccionNormalizada[] DireccionesNormalizadas { get; set; }
    }

    public class DireccionNormalizada
    {
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
    }
}