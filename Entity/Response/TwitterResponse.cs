using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Entity
{
	/// <summary>
	/// Twitter APIから受信したデータを扱う基底クラスです。
	/// </summary>
	[Serializable]
	abstract public class TwitterResponse
	{
		/// <summary>
		/// Twitterから送信される時間の形式<para />
		/// Example : Thu Jan 18 00:10:45 +0000 2007
		/// </summary>
		public const string DateTimeFormat = "ddd MMM d HH':'mm':'ss zzz yyyy";

		/// <summary>
		/// TwitterResponseを初期化します。
		/// </summary>
		public TwitterResponse()
		{
			this.StringJson = null;
			this.Json = null;
		}

		/// <summary>
		/// TwitterResponseを初期化します。
		/// </summary>
		/// <param name="source">Json ソース</param>
		public TwitterResponse(string source)
		{
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
