using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Apis
{
	public class Response<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }

		public Response(bool sucess, string message)
		{
			Success = sucess;
			Message = message;
		}

		public Response(T data)
		{
			Success = true;

			if (data != null)
			{
				// Obtener todas las propiedades públicas del objeto
				var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

				// Comprobar si todas las propiedades son nulas
				if (!properties.All(prop => prop.GetValue(data) == null))
				{
					Data = data;
				}
			}
		}
	}
}
