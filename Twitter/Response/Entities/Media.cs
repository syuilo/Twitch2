using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Response.Entities
{
	/// <summary>
	/// Media情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class Media : TwitterResponse
	{
		public Media()
			: base() { }

		public Media(Twitter twitter, string source)
			: base(twitter, source)
		{
				this.ExpandedUrl = new Uri(this.Json["expanded_url"]);
				this.Url = new Uri(this.Json["url"]);
				this.Indices = this.Json["indices"];
				this.DisplayUrl = this.Json["display_url"];
				this.ID = this.Json["id"];
				this.StringID = this.Json["id_str"];
				this.MediaUrl = new Uri(this.Json["media_url"]);
				this.MediaUrlHttps = new Uri(this.Json["media_url_https"]);
				this.Sizes = new Sizes(twitter, this.Json["sizes"].ToString());
				this.SourceStatusID = (this.Json.IsDefined("source_status_id")) ? (Int64?)this.Json["source_status_id"] : null;
				this.SourceStatusStringID = (this.Json.IsDefined("source_status_id_str")) ? this.Json["source_status_id_str"] : null;
				this.Type = this.Json["type"];
		}

		/// <summary>
		/// MediaのID。
		/// </summary>
		public double ID
		{
			get;
			private set;
		}

		/// <summary>
		/// MediaのID。
		/// </summary>
		public string StringID
		{
			get;
			private set;
		}

		/// <summary>
		/// 元のURL。
		/// </summary>
		public Uri ExpandedUrl
		{
			get;
			private set;
		}

		/// <summary>
		/// t.coにより短縮されたURL。
		/// </summary>
		public Uri Url
		{
			get;
			private set;
		}

		/// <summary>
		/// ツイート内の、このURLのオフセットを表す整数の配列。
		/// 最初の整数は、ツイート内のURLの最初の文字の位置を表しています。
		/// 第二の整数は、URLの末尾の後の最初の非URL文字の位置を表しています。
		/// </summary>
		public double[] Indices
		{
			get;
			private set;
		}

		/// <summary>
		/// クライアントに表示されるURL。
		/// </summary>
		public string DisplayUrl
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Uri MediaUrl
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Uri MediaUrlHttps
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Sizes Sizes
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Int64? SourceStatusID
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string SourceStatusStringID
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			get;
			private set;
		}
	}
}
