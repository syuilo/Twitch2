using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;

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
			Dictionary<string, string> query = null,
			string proxy = null,
			string userAgent = null)
		{
			this.Twitter = twitter;
			this.Method = method;
			this.Url = url;
			this.Parameter = query;
			this.Proxy = proxy;
			this.UserAgent = userAgent ?? twitter.UserAgent;
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
		public Dictionary<string, string> Parameter
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
				var para = from k in this.Parameter
						   select (k.Value != null)
						   ? Core.UrlEncode(k.Key, Encoding.UTF8) + '=' + Core.UrlEncode(k.Value, Encoding.UTF8)
						   : null;

				data = String.Join("&", para.ToArray());

				Debug.WriteLine(data.Length > 1000 ? "## リクエストデータ構築完了 : (1000文字以上)" : "## リクエストデータ構築完了 : " + data);

				if (this.Method == Method.GET)
					url += '?' + data;
			}

			// Create request
			var clientHandler = new HttpClientHandler();
			var client = new HttpClient(clientHandler);

			if (this.Proxy != null)
				clientHandler.Proxy = new WebProxy(this.Proxy);

			client.DefaultRequestHeaders.Add("Authorization",
				Core.GenerateRequestHeader(
					this.Twitter, this.Method.ToString(), this.Url.ToString(), this.Parameter));

			if (!String.IsNullOrEmpty(this.UserAgent))
				client.DefaultRequestHeaders.Add("User-Agent", this.UserAgent);

			Debug.WriteLine("## リクエストを送信します...");

			HttpResponseMessage response = null;

			try
			{
				// Send request
				if (this.Method == Method.GET)
				{
					response = await client.GetAsync(url);
				}
				if (this.Method == Method.POST)
				{
					response = await client.PostAsync(this.Url, new FormUrlEncodedContent((this.Parameter != null) ? this.Parameter : new Dictionary<string, string>()));
				}

				// Read response
				var receive = await response.Content.ReadAsStringAsync();

				try
				{
					var json = Utility.DynamicJson.Parse(receive);
					if (json.IsDefined("errors"))
						foreach (var error in json.errors)
							throw new ApiException(error.message);
				}
				catch (System.Xml.XmlException ex) { }

				Debug.WriteLine("## " + response.StatusCode + " " + response.ReasonPhrase + " : " + receive + "\r\n--------------------");
				return receive;
			}
			catch (HttpRequestException ex)
			{
				if (ex.InnerException.GetType().FullName == "System.Net.WebException")
				{
					var ex2 = (WebException)ex.InnerException;
					if (ex2.Status == WebExceptionStatus.ProtocolError)
					{
						var res = (HttpWebResponse)ex2.Response;
						Debug.WriteLine("## HTTPエラー : " + ex2.Message + "\r\n--------------------");
						throw new ApiException(res.StatusCode, res.StatusDescription);
					}
				}
				Debug.WriteLine("## エラー : " + ex.Message + "\r\n--------------------");
				throw ex;
			}
		}
	}
}
