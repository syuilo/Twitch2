using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Twitch.OAuth;
using Twitch.API;

namespace Twitch
{
	/// <summary>
	/// Twitterへのリクエストを作成します。
	/// </summary>
	public class TwitterRequest
	{
		/// <summary>
		/// Twitterへのリクエストを作成します。
		/// </summary>
		/// <param name="twitter">リクエストを行うTwitterオブジェクト。</param>
		/// <param name="method">APIのリクエストに使用するHTTPメソッド。</param>
		/// <param name="url">APIのURL。</param>
		/// <param name="query">リクエストのパラメータ。</param>
		public TwitterRequest(
			Twitter twitter = null,
			Method method = Method.POST,
			Uri url = null,
			StringDictionary query = null,
			string proxy = null,
			string userAgent = null)
		{
			this.Twitter = twitter;
			this.Method = method;
			this.Url = url;
			this.Parameter = query;
			this.Proxy = proxy;
			this.UserAgent = userAgent;
		}

		/// <summary>
		/// リクエストを行うユーザーのTwitterオブジェクト。
		/// </summary>
		public Twitter Twitter
		{
			get;
			set;
		}

		/// <summary>
		/// APIのリクエストに使用するHTTPメソッド。
		/// 適当なメソッドについては各種APIドキュメントを参照してください。
		/// </summary>
		public Method Method
		{
			get;
			set;
		}

		/// <summary>
		/// APIのURL。
		/// </summary>
		public Uri Url
		{
			get;
			set;
		}

		/// <summary>
		/// リクエストのパラメータ。
		/// </summary>
		public StringDictionary Parameter
		{
			get;
			set;
		}

		/// <summary>
		/// リクエストに使用するプロキシ サーバー。
		/// </summary>
		public string Proxy
		{
			get;
			set;
		}

		public string UserAgent
		{
			get;
			set;
		}

		/// <summary>
		/// 非同期でリクエストを送信し、レスポンスを取得します。
		/// </summary>
		/// <returns>レスポンス</returns>
		public async Task<string> Request()
		{
			string data = null;
			string url = this.Url.ToString();

			Debug.WriteLine("\r\n--------------------\r\n## リクエストを作成します > " + this.Method + " " + this.Url);

			if (this.Parameter != null)
			{
				var para = from DictionaryEntry k in this.Parameter
						   select (k.Value != null)
						   ? Core.UrlEncode((string)k.Key, Encoding.UTF8) + '=' + Core.UrlEncode((string)k.Value, Encoding.UTF8)
						   : null;

				data = String.Join("&", para.ToArray());

				Debug.WriteLine(data.Length > 1000 ? "## リクエストデータ構築完了 : (1000文字以上)" : "## リクエストデータ構築完了 : " + data);

				if (Method == Method.GET)
					url += '?' + data;
			}

			// Create request
			var request = (HttpWebRequest)WebRequest.Create(url);

			if (this.Proxy != null)
				request.Proxy = new WebProxy(this.Proxy);

			request.Method = Method.ToString();
			request.ContentType = "application/x-www-form-urlencoded";
			request.Host = "api.twitter.com";
			request.Headers["Authorization"] =
				Core.GenerateRequestHeader(
					this.Twitter, Method.ToString(), this.Url.ToString(), this.Parameter);

			if (!String.IsNullOrEmpty(this.UserAgent))
				request.UserAgent = this.UserAgent;

			if (Method == Method.POST && this.Parameter != null)
			{
				// Write request data
				using (StreamWriter streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
					await streamWriter.WriteAsync(data);
			}

			Debug.WriteLine("## リクエストを送信します...");

			try
			{
				// Send request
				var response = (HttpWebResponse)await request.GetResponseAsync();

				// Read response
				using (StreamReader responseDataStream = new StreamReader(response.GetResponseStream()))
				{
					var receive = await responseDataStream.ReadToEndAsync();

					Debug.WriteLine("## " + response.StatusCode + " " + response.StatusDescription + " : " + receive + "\r\n--------------------");
					return receive;
				}
			}
			catch (System.Net.WebException ex)
			{
				if (ex.Status == System.Net.WebExceptionStatus.ProtocolError)
				{
					Debug.WriteLine("## HTTPエラー : " + ex.Message + "\r\n--------------------");
					throw ex;
				}
				else
				{
					Debug.WriteLine("## エラー : " + ex.Message + "\r\n--------------------");
					throw ex;
				}
			}
		}
	}
}
