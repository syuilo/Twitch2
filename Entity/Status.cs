using System;
using System.Threading.Tasks;

namespace Twitch.Entity
{
	/// <summary>
	/// ツイートを格納するツイート オブジェクトです。
	/// </summary>
	[Serializable]
	public class Status : Response.Tweets.Status
	{
		public Status()
			: base() { }

		public Status(string source)
			: base(source) { }

		/// <summary>
		/// お気に入りに登録します。
		/// </summary>
		/// <returns>ツイートオブジェクト</returns>
		public async Task<Status> Favorite(Twitter twitter)
		{
			return await twitter.FavoritesCreate(this.ID);
		}

		/// <summary>
		/// お気に入りを解除します。
		/// </summary>
		/// <returns>ツイートオブジェクト</returns>
		public async Task<Status> UnFavorite(Twitter twitter)
		{
			return await twitter.FavoritesDestroy(this.ID);
		}

		/// <summary>
		/// リツイートします。
		/// </summary>
		/// <returns>ツイートオブジェクト</returns>
		public async Task<Status> Retweet(Twitter twitter)
		{
			return await twitter.StatusesRetweet(this.ID);
		}
	}
}
