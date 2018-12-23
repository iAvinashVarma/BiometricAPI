using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BiometricAPI.Formatter
{
	/// <summary>
	/// 
	/// </summary>
	public class CSVMediaTypeFormatter : MediaTypeFormatter
	{
		/// <summary>
		/// 
		/// </summary>
		public CSVMediaTypeFormatter()
		{

			SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="mediaTypeMapping"></param>
		public CSVMediaTypeFormatter(
			MediaTypeMapping mediaTypeMapping) : this()
		{

			MediaTypeMappings.Add(mediaTypeMapping);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="mediaTypeMappings"></param>
		public CSVMediaTypeFormatter(
			IEnumerable<MediaTypeMapping> mediaTypeMappings) : this()
		{

			foreach (var mediaTypeMapping in mediaTypeMappings)
			{
				MediaTypeMappings.Add(mediaTypeMapping);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public override bool CanReadType(Type type)
		{
			if (type == null)
				throw new ArgumentNullException("type");

			return IsTypeOfIEnumerable(type);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public override bool CanWriteType(Type type)
		{
			if (type == null)
				throw new ArgumentNullException("type");

			return IsTypeOfIEnumerable(type);
		}

		private bool IsTypeOfIEnumerable(Type type)
		{

			foreach (Type interfaceType in type.GetInterfaces())
			{

				if (interfaceType == typeof(IEnumerable))
					return true;
			}

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <param name="writeStream"></param>
		/// <param name="content"></param>
		/// <param name="transportContext"></param>
		/// <returns></returns>
		public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
		{
			WriteStream(type, value, writeStream, transportContext);
			var tcs = new TaskCompletionSource<int>();
			tcs.SetResult(0);
			return tcs.Task;
		}

		private void WriteStream(Type type, object value, Stream stream, TransportContext contentHeaders)
		{

			//NOTE: We have check the type inside CanWriteType method
			//If request comes this far, the type is IEnumerable. We are safe.

			Type itemType = type.GetGenericArguments()[0];

			var _stringWriter = new StringWriter();

			_stringWriter.WriteLine(
				string.Join<string>(
					",", itemType.GetProperties().Select(x => x.Name)
				)
			);

			foreach (var obj in (IEnumerable<object>)value)
			{

				var vals = obj.GetType().GetProperties().Select(
					pi => new {
						Value = pi.GetValue(obj, null)
					}
				);

				string _valueLine = string.Empty;

				foreach (var val in vals)
				{

					if (val.Value != null)
					{

						var _val = val.Value.ToString();

						//Check if the value contans a comma and place it in quotes if so
						if (_val.Contains(","))
							_val = string.Concat("\"", _val, "\"");

						//Replace any \r or \n special characters from a new line with a space
						if (_val.Contains("\r"))
							_val = _val.Replace("\r", " ");
						if (_val.Contains("\n"))
							_val = _val.Replace("\n", " ");

						_valueLine = string.Concat(_valueLine, _val, ",");

					}
					else
					{

						_valueLine = string.Concat(string.Empty, ",");
					}
				}

				_stringWriter.WriteLine(_valueLine.TrimEnd(','));
			}

			var streamWriter = new StreamWriter(stream);
			streamWriter.Write(_stringWriter.ToString());
		}
	}
}