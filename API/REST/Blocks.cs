using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// 指定したユーザーをブロックします。
		/// </summary>
		/// <param name="screen_name">ブロックするユーザーのScreenName。</param>
		/// <param name="id">ブロックするユーザーのID。</param>
		/// <returns>ブロックされたユーザー</returns>
		public async Task<User> Create(string screen_name = null, Int64? id = null)
		{
			var query = new StringDictionary();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Blocks_Create), query));
		}

		/// <summary>
		/// 指定したユーザーのブロックを解除します。
		/// </summary>
		/// <param name="screen_name">ブロックを解除するユーザーのScreenName。</param>
		/// <param name="id">ブロックを解除するユーザーのID。</param>
		/// <returns>ブロックを解除されたユーザー</returns>
		public async Task<User> Destroy(string screen_name = null, Int64? id = null)
		{
			var query = new StringDictionary();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Blocks_Destroy), query));
		}
	}
}
