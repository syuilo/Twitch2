using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Response.Entities
{
	/// <summary>
	/// Sizes情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class Sizes : TwitterResponse
	{
		public Sizes()
			: base() { }

		public Sizes(Twitter twitter, string source)
			: base(twitter, source)
		{
			this.Thumb = new Size(twitter, this.Json["thumb"].ToString());
			this.Large = new Size(twitter, this.Json["large"].ToString());
			this.Medium = new Size(twitter, this.Json["medium"].ToString());
			this.Small = new Size(twitter, this.Json["small"].ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Thumb
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Large
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Medium
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Small
		{
			get;
			private set;
		}
	}
}
