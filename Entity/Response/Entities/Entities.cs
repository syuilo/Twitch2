using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Entity.Response.Entities
{
	/// <summary>
	/// Entities情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class Entities : TwitterResponse
	{
		public Entities()
			: base() { }

		public Entities(string source)
			: base(source)
		{
			this.Hashtags = new List<Hashtag>();
			foreach (dynamic hashtag in this.Json["hashtags"])
			{
				this.Hashtags.Add(
					new Hashtag(hashtag.ToString()));
			}

			if (this.Json.IsDefined("media"))
			{
				this.Media = new List<Media>();
				foreach (dynamic media in this.Json["media"])
				{
					this.Media.Add(
						new Media(media.ToString()));
				}
			}

			this.Urls = new List<URL>();
			foreach (dynamic url in this.Json["urls"])
			{
				this.Urls.Add(
					new URL(url.ToString()));
			}

			this.UserMentions = new List<UserMentions>();
			foreach (dynamic userMentions in this.Json["user_mentions"])
			{
				this.UserMentions.Add(
					new UserMentions(userMentions.ToString()));
			}
		}

		/// <summary>
		/// ツイートに含まれるハッシュタグ。
		/// </summary>
		public List<Hashtag> Hashtags
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public List<Media> Media
		{
			get;
			private set;
		}

		/// <summary>
		/// ツイートに含まれるURL。
		/// </summary>
		public List<URL> Urls
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public List<UserMentions> UserMentions
		{
			get;
			private set;
		}
	}
}
