using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Response.Entities
{
	/// <summary>
	/// メンション情報を格納する <see cref="Twitch.TwitterResponse"/> です。
	/// </summary>
	[Serializable]
	public class UserMentions : TwitterResponse
	{
		public UserMentions()
			: base() { }

		public UserMentions(string source)
			: base(source)
		{
			this.ID = (Int64)this.Json["id"];
			this.StringID = this.Json["id_str"];
			this.Indices = this.Json["indices"];
			this.Name = this.Json["name"];
			this.ScreenName = this.Json["screen_name"];
		}

		/// <summary>
		/// ユーザーID
		/// </summary>
		public Int64 ID
		{
			get;
			private set;
		}

		/// <summary>
		/// ユーザーID
		/// </summary>
		public string StringID
		{
			get;
			private set;
		}

		/// <summary>
		/// ツイート内の、このメンションのオフセットを表す整数の配列。<para />
		/// 最初の整数は、ツイート内のメンションの'@'文字の位置を表しています。<para />
		/// 第二の整数は、メンションの末尾の後の最初の非ScreenName文字の位置を表しています。
		/// </summary>
		public int[] Indices
		{
			get;
			private set;
		}

		/// <summary>
		/// ユーザー名
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// スクリーン名 (@以降)
		/// </summary>
		public string ScreenName
		{
			get;
			private set;
		}
	}
}
