﻿using BimManager.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BimManager.Logica.Apis
{
    public class ApisPeru
	{
		#region Response

		public class ApisPeruSuccessResponse<T>
		{
			public T Data { get; set; }
		}

		public class ApisPeruErrorResponse
		{
			public string Message { get; set; }
		}

		#endregion

		#region Entidades
		public class ApisPeruPersonaNatural
		{
			public string Dni { get; set; }
			public string Nombres { get; set; }
			public string ApellidoPaterno { get; set; }
			public string ApellidoMaterno { get; set; }
			public string CodVerifica { get; set; }
		}

		public class ApisPeruPersonaJuridica
		{
			public string Ruc { get; set; }
			public string RazonSocial { get; set; }
			public string NombreComercial { get; set; }
			public List<string> Telefonos { get; set; }
			public string Estado { get; set; }
			public string Condicion { get; set; }
			public string Direccion { get; set; }
			public string Departamento { get; set; }
			public string Provincia { get; set; }
			public string Distrito { get; set; }
			public string Ubigeo { get; set; }
			public string Capital { get; set; }
		}
		#endregion

		private static readonly ApisPeru _instancia = new ApisPeru();
		public static ApisPeru Instancia { get { return _instancia; } }

		private readonly string apiBase = "https://dniruc.apisperu.com/api/v1/";
		private readonly string token = "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU";

		public async Task<Cliente> GetCliente_PersonaNaturalAsync(string dni)
		{
			try
			{ 
				var url = GetApiURL("dni", dni);
				var response = await GetResponseAsync<ApisPeruPersonaNatural>(url);
				if (response.Success && response.Data != null)
				{
					return new Cliente
					{
						TipoDocumentoIdentidadID = 1,
						DocumentoIdentidadNumero = dni,
						Nombres = response.Data.Nombres,
						Apellido1 = response.Data.ApellidoPaterno,
						Apellido2 = response.Data.ApellidoMaterno,
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
				var url = GetApiURL("ruc", ruc);
				var response = await GetResponseAsync<ApisPeruPersonaJuridica>(url);
				if (response.Success && response.Data != null)
				{
					return new Cliente
					{
						TipoDocumentoIdentidadID = 2,
						DocumentoIdentidadNumero = ruc,
						RazonSocial = response.Data.RazonSocial,
						Celular = response.Data.Telefonos != null ? response.Data.Telefonos.FirstOrDefault() : null
					};
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

		private async Task<Response<T>> GetResponseAsync<T>(string url)
		{
			using (var _httpClient = new HttpClient())
			{
				var response = await _httpClient.GetAsync(url);
				var jsonResponse = await response.Content.ReadAsStringAsync();
				if (response.IsSuccessStatusCode)
				{
					var successReponse = JsonConvert.DeserializeObject<T>(jsonResponse);
					return new Response<T>(successReponse);
				}
				else
				{
					var errorReponse = JsonConvert.DeserializeObject<ApisPeruErrorResponse>(jsonResponse);
					return new Response<T>(false, errorReponse.Message);
				}
			}				
		}

		private string GetApiURL(string tipo, string numeroDocumento)
		{
			return $"{apiBase}{tipo}/{numeroDocumento}{token}";
		}
	}
}