using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Response.Entities
{
	/// <summary>
	/// ハッシュタグ情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class Hashtag : TwitterResponse
	{
		public Hashtag()
			: base() { }

		public Hashtag(string source)
			: base(source)
		{
			this.Indices = this.Json["indices"];
			this.Text = this.Json["text"];
		}

		/// <summary>
		/// ツイート内の、このハッシュタグのオフセットを表す整数の配列。<para />
		/// 最初の整数は、ツイート内のハッシュタグの最初の文字の位置を表しています。<para />
		/// 第二の整数は、ハッシュタグの末尾の後の最初の非ハッシュタグ文字の位置を表しています。
		/// </summary>
		public int[] Indices
		{
			get;
			private set;
		}

		/// <summary>
		/// ハッシュタグ記号(#)を含めないハッシュタグ文字列。
		/// </summary>
		public string Text
		{
			get;
			private set;
		}
	}
}
