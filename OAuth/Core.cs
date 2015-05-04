using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

namespace Twitch.OAuth
{
	/// <summary>
	/// OAuthを扱う基底クラス
	/// </summary>
	public static class Core
	{
		/// <summary>
		/// リクエスト ヘッダー文字列を生成します。
		/// </summary>
		/// <param name="context">リクエストに使用されるトークンセット。</param>
		/// <param name="method"></param>
		/// <param name="requestUrl"></param>
		/// <param name="queryDictionary"></param>
		/// <returns></returns>
		public static string GenerateRequestHeader(Twitter context, string method, string requestUrl, StringDictionary queryDictionary = null)
		{
			Debug.WriteLine("-\t## リクエスト ヘッダーを構築します");

			string header = String.Empty;
			string headerParams = String.Empty;

			var oauth = new OAuthBase();
			string nonce = oauth.GenerateNonce();
			string timeStamp = oauth.GenerateTimeStamp();

			var paramDictionary = new SortedDictionary<string, string>();
			AddPercentEncodedItem(paramDictionary, "oauth_consumer_key", context.ConsumerKey);
			AddPercentEncodedItem(paramDictionary, "oauth_nonce", nonce);
			AddPercentEncodedItem(paramDictionary, "oauth_signature", GenerateSignature(context, method, requestUrl, nonce, "HMAC-SHA1", timeStamp, "1.0", queryDictionary));
			AddPercentEncodedItem(paramDictionary, "oauth_signature_method", "HMAC-SHA1");
			AddPercentEncodedItem(paramDictionary, "oauth_timestamp", timeStamp);
			AddPercentEncodedItem(paramDictionary, "oauth_token", context.AccessToken != null ? context.AccessToken : null);
			AddPercentEncodedItem(paramDictionary, "oauth_version", "1.0");

			foreach (var kvp in paramDictionary)
			{
				if (kvp.Value != null)
					headerParams += (headerParams.Length > 0 ? ", " : String.Empty) + kvp.Key + "=\"" + kvp.Value + "\"";
			}

			header = "OAuth " + headerParams;

			Debug.WriteLine("-\t## リクエスト ヘッダー構築完了: [Authorization] " + header);
			return header;
		}

		/// <summary>
		/// シグネチャ文字列を生成します。
		/// </summary>
		/// <param name="context">リクエストに使用されるトークンセット。</param>
		/// <param name="method">リクエストのメソッド。</param>
		/// <param name="url">リクエストのURL。</param>
		/// <param name="nonce">ランダムな文字列。</param>
		/// <param name="signatureMethod">シグネチャ メソッド。</param>
		/// <param name="timeStamp">現在の時刻のタイムスタンプ。</param>
		/// <param name="oAuthVersion">OAuthのバージョン文字列。</param>
		/// <param name="QueryDictionary">リクエストのパラメータ。</param>
		/// <returns></returns>
		public static string GenerateSignature(Twitter context, string method, string url, string nonce, string signatureMethod, string timeStamp, string oAuthVersion, StringDictionary QueryDictionary = null)
		{
			Debug.WriteLine("-\t-\t## シグネチャを生成します");

			var parameters = new SortedDictionary<string, string>();
			parameters.Add("oauth_consumer_key", context.ConsumerKey);
			parameters.Add("oauth_nonce", nonce);
			parameters.Add("oauth_signature_method", signatureMethod);
			parameters.Add("oauth_timestamp", timeStamp);
			parameters.Add("oauth_token", context.AccessToken != null ? context.AccessToken : null);
			parameters.Add("oauth_version", oAuthVersion);

			// Add parameters to request parameter
			if (QueryDictionary != null)
			{
				foreach (DictionaryEntry k in QueryDictionary)
				{
					if (k.Value != null)
						parameters.Add((string)k.Key, (string)k.Value);
				}
			}

#if DEBUG
			foreach (KeyValuePair<string, string> p in parameters)
			{
				if (p.Value != null)
					Debug.WriteLine(p.Value.Length > 1000 ? "-\t-\t-\t## [" + p.Key + "] : (1000文字以上)" : "-\t-\t-\t## [" + p.Key + "] : " + p.Value);
			}
#endif

			string stringParameter = String.Empty;

			foreach (var kvp in parameters)
			{
				if (kvp.Value != null)
					stringParameter +=
						(stringParameter.Length > 0 ? "&" : String.Empty) +
						UrlEncode(kvp.Key, Encoding.UTF8) +
						"=" + UrlEncode(kvp.Value, Encoding.UTF8);
			}

			Debug.WriteLine(stringParameter.Length > 1000 ? "-\t-\t-\t## パラメータ生成完了: (1000文字以上)" : "-\t-\t-\t## パラメータ生成完了: " + stringParameter);

			// Generate signature base string
			string signatureBaseString = UrlEncode(method, Encoding.UTF8) + "&"
				+ UrlEncode(url, Encoding.UTF8) + "&"
				+ UrlEncode(stringParameter, Encoding.UTF8);

			Debug.WriteLine(signatureBaseString.Length > 1000 ? "-\t-\t-\t## シグネチャ ベース ストリング生成完了: (1000文字以上)" : "-\t-\t-\t## シグネチャ ベース ストリング生成完了: " + signatureBaseString);

			var hmacsha1 = new HMACSHA1(Encoding.ASCII.GetBytes(
				UrlEncode(context.ConsumerSecret, Encoding.UTF8) +
				"&" + (!String.IsNullOrEmpty(context.AccessTokenSecret) ? UrlEncode(context.AccessTokenSecret, Encoding.UTF8) : String.Empty)));

			// Convert to Base64
			string signature = Convert.ToBase64String(hmacsha1.ComputeHash(Encoding.ASCII.GetBytes(signatureBaseString)));

			Debug.WriteLine("-\t-\t## シグネチャ生成完了: " + signature);
			return signature;
		}

		/// <summary>
		/// パラメーター名および値をパーセントエンコードしてディクショナリに追加
		/// </summary>
		private static void AddPercentEncodedItem(SortedDictionary<string, string> dictionary, string key, string keyValue)
		{
			if (!string.IsNullOrEmpty(keyValue))
				dictionary.Add(UrlEncode(key, Encoding.UTF8), UrlEncode(keyValue, Encoding.UTF8));
		}

		/// <summary>
		/// 与えられた文字列をURLエンコードします。
		/// </summary>
		/// <param name="value">URLエンコードする文字列。</param>
		/// <param name="encode">文字コード。</param>
		/// <returns></returns>
		public static string UrlEncode(string value, Encoding encode)
		{
			string unreservedChars = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

			var result = new StringBuilder();
			byte[] data = encode.GetBytes(value);
			int len = data.Length;

			for (int i = 0; i < len; i++)
			{
				int c = data[i];

				if (c < 0x80 && unreservedChars.IndexOf((char)c) != -1)
					result.Append((char)c);
				else
					result.Append('%' + String.Format("{0:X2}", (int)data[i]));
			}

			return result.ToString();
		}
	}
}
