using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// 対象のツイートをお気に入りに登録します。
		/// </summary>
		/// <param name="id">対象のツイートのID。</param>
		/// <returns>対象のツイート</returns>
		public async Task<Status> FavoritesCreate(Int64 id)
		{
			var query = new StringDictionary();
			query["id"] = id.ToString();

			string res = await this.Request(API.Method.POST, new Uri(API.Urls.Favorites_Create), query);
			return res != null ? new Status(res) : null;
		}

		/// <summary>
		/// 対象のツイートをお気に入りから削除します。
		/// </summary>
		/// <param name="id">対象のツイートのID。</param>
		/// <returns>対象のツイート</returns>
		public async Task<Status> FavoritesDestroy(Int64 id)
		{
			var query = new StringDictionary();
			query["id"] = id.ToString();

			string res = await this.Request(API.Method.POST, new Uri(API.Urls.Favorites_Destroy), query);
			return res != null ? new Status(res) : null;
		}
	}
}
