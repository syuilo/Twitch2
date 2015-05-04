﻿using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// 指定されたユーザーをミュートします。
		/// </summary>
		/// <param name="screen_name">ミュートするユーザーのScreenName。</param>
		/// <param name="id">ミュートするユーザーのID。</param>
		/// <returns>ミュートされたユーザー</returns>
		public async Task<User> UsersCreate(string screen_name = null, string id = null)
		{
			var query = new StringDictionary();
			query["screen_name"] = screen_name;
			query["user_id"] = id;

			return new User(this,
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Mutes_Users_Create), query));
		}

		/// <summary>
		/// 指定したユーザーのミュートを解除します。
		/// </summary>
		/// <param name="screen_name">ミュートを解除するユーザーのScreenName。</param>
		/// <param name="id">ミュートを解除するユーザーのID。</param>
		/// <returns>ミュートを解除されたユーザー</returns>
		public async Task<User> UsersDestroy(string screen_name = null, string id = null)
		{
			var query = new StringDictionary();
			query["screen_name"] = screen_name;
			query["user_id"] = id;

			return new User(this,
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Mutes_Users_Destroy), query));
		}
	}
}