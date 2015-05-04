using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch
{
	/// <summary>
	/// Twitter APIから受信したデータを扱う基底クラスです。
	/// </summary>
	[Serializable]
	abstract public class TwitterResponse
	{
		// Example : Thu Jan 18 00:10:45 +0000 2007
		public const string DateTimeFormat = "ddd MMM d HH':'mm':'ss zzz yyyy";

		public TwitterResponse()
		{
			this.StringJson = null;
			this.Json = null;
		}

		/// <summary>
		/// TwitterResponseを初期化します。
		/// </summary>
		/// <param name="source">Json ソース</param>
		public TwitterResponse(Twitter twitter, string source)
		{
			this.Twitter = twitter;

			if (source != null)
			{
				this.StringJson = source;

				try
				{
					this.Json = Utility.DynamicJson.Parse(source);
				}
				catch
				{
					throw new Exception(
						"Jsonの解析に失敗しました。");
				}
			}
			else
				throw new Exception(
					"データ ソースが空です。TwitterResponseの初期化には、元となるJson ソースを与える必要があります。");
		}

		/// <summary>
		/// このエンティティに対して操作を行うためのTwitterオブジェクト
		/// </summary>
		protected Twitter Twitter
		{
			get;
			set;
		}

		/// <summary>
		/// Twitterから受信した、オブジェクトの基となるJson形式の文字列(レスポンス)。
		/// </summary>
		protected string StringJson
		{
			get;
			set;
		}

		/// <summary>
		/// Twitterから受信した、オブジェクトの基となるJson オブジェクト。
		/// </summary>
		protected dynamic Json
		{
			get;
			set;
		}

		/// <summary>
		/// JSON文字列を返します。
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.StringJson;
		}

		/// <summary>
		/// Jsonオブジェクトを返します。
		/// </summary>
		/// <returns>Dynamic Json</returns>
		public dynamic ToJson()
		{
			var json = Utility.DynamicJson.Parse(StringJson);

			return json;
		}
	}
}
