using System;
using System.Net;

namespace Twitch.API
{
	/// <summary>
	/// Twitter APIで発生するエラー。
	/// </summary>
	public class ApiException : Exception
	{
		public ApiException() { }

		public ApiException(string message) : base(message) { }

		public ApiException(HttpStatusCode statusCode, string message) : base(statusCode + " " + message) {
			this.StatusCode = statusCode;
		}

		public HttpStatusCode StatusCode
		{
			get;
			set;
		}
	}
}
