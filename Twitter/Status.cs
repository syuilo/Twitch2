using System;
using System.Threading.Tasks;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// ツイートを格納するツイート オブジェクトです。
		/// </summary>
		[Serializable]
		public class Status : Response.Tweets.Status
		{
			public Status()
				: base() { }

			public Status(Twitter twitter, string source)
				: base(twitter, source) { }

			/// <summary>
			/// お気に入りに登録します。
			/// </summary>
			/// <returns>ツイートオブジェクト</returns>
			public async Task<Status> Favorite()
			{
				return await this.Twitter.FavoritesCreate(this.ID);
			}

			/// <summary>
			/// お気に入りを解除します。
			/// </summary>
			/// <returns>ツイートオブジェクト</returns>
			public async Task<Status> UnFavorite()
			{
				return await this.Twitter.FavoritesDestroy(this.ID);
			}

			/// <summary>
			/// リツイートします。
			/// </summary>
			/// <returns>ツイートオブジェクト</returns>
			public async Task<Status> Retweet()
			{
				return await this.Twitter.StatusesRetweet(this.ID);
			}
		}
	}
}
