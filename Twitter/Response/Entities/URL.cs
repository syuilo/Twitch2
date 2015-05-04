using System;

namespace Twitch.Response.Entities
{
	/// <summary>
	/// URL情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class URL : TwitterResponse
	{
		public URL()
			: base() { }

		public URL(Twitter twitter, string source)
			: base(twitter, source)
		{
				this.ExpandedUrl = new Uri(this.Json["expanded_url"]);
				this.Url = new Uri(this.Json["url"]);
				this.Indices = this.Json["indices"];
				this.DisplayUrl = this.Json["display_url"];
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
		/// ツイート内の、このURLのオフセットを表す整数の配列。<para />
		/// 最初の整数は、ツイート内のURLの最初の文字の位置を表しています。<para />
		/// 第二の整数は、URLの末尾の後の最初の非URL文字の位置を表しています。
		/// </summary>
		public int[] Indices
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
	}
}
