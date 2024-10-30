using BimManager.Entidad;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BimManager.Logica.Apis
{
    public class ConsultaDatosReniec
    {
		#region Response

		public class ConsultaDatosReniecSuccessResponse<T>
		{
			public bool Success { get; set; }
			public string Message { get; set; }
			public T Data { get; set; }
		}

		public class ConsultaDatosReniecErrorResponse
        {
			public string Message { get; set; }
		}

		#endregion

		#region Entidades
		public class ConsultaDatosReniecPersonaNatural
		{
			public string Numero { get; set; }
			public string Nombres { get; set; }
			public string Apellido_Paterno { get; set; }
			public string Apellido_Materno { get; set; }
            public string Codigo_Verificacion { get; set; }
        }

		public class ConsultaDatosReniecPersonaJuridica
		{
			public string NumeroDocumento { get; set; }
			public string Nombre { get; set; }
			public string Condicion { get; set; }
			public string Direccion { get; set; }
			public string Departamento { get; set; }
			public string Provincia { get; set; }
			public string Distrito { get; set; }
		}
		#endregion



		private static readonly ConsultaDatosReniec _instancia = new ConsultaDatosReniec();
		public static ConsultaDatosReniec Instancia { get { return _instancia; } }

		private readonly string apiBase = "https://dni.consultadatosreniec.online/";

		public async Task<Cliente> GetCliente_PersonaNaturalAsync(string dni)
		{
			try
			{
				var url = GetApiURL("consultdni", dni);
				var response = await GetResponseAsync<ConsultaDatosReniecPersonaNatural>(url);
				if (response.Success && response.Data != null)
				{
					return new Cliente
					{
						TipoDocumentoIdentidadID = 1,
						DocumentoIdentidadNumero = dni,
						Nombres = response.Data.Nombres,
						Apellido1 = response.Data.Apellido_Paterno,
						Apellido2 = response.Data.Apellido_Materno,
					};
				}
			}
			catch (Exception)
			{ 
            }

            return null;
        }

		public async Task<Cliente> GetCliente_PersonaJuridicaAsync(string ruc)
		{
			try
			{ 
				var url = GetApiURL("consultaruc", ruc);
				var response = await GetResponseAsync<ConsultaDatosReniecPersonaJuridica>(url, true);
				if (response.Success && response.Data != null)
				{
					return new Cliente
					{
						TipoDocumentoIdentidadID = 2,
						DocumentoIdentidadNumero = ruc,
						RazonSocial = response.Data.Nombre,
					};
                }
            }
            catch (Exception)
            {
            }

            return null;
        }

		private async Task<Response<T>> GetResponseAsync<T>(string url, bool personaJuridica = false)
		{
			using (var _httpClient = new HttpClient())
			{
				var response = await _httpClient.GetAsync(url);
				var jsonResponse = await response.Content.ReadAsStringAsync();
				if (response.IsSuccessStatusCode)
				{
					if (personaJuridica)
					{
                        var successReponse = JsonConvert.DeserializeObject<T>(jsonResponse);
                        return new Response<T>(successReponse);
                    }
					else
					{
						var successReponse = JsonConvert.DeserializeObject<ConsultaDatosReniecSuccessResponse<T>>(jsonResponse);
						return new Response<T>(successReponse.Data);
					}
				}
				else
				{
					var errorReponse = JsonConvert.DeserializeObject<ConsultaDatosReniecErrorResponse>(jsonResponse);
					return new Response<T>(false, errorReponse.Message);
				}
			}				
		}

		private string GetApiURL(string tipo, string numeroDocumento)
		{
			return $"{apiBase}{tipo}/{numeroDocumento}";
		}
	}
}