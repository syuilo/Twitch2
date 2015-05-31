using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch.API
{
	public partial class Rest
	{
		public static async Task<User> BlocksCreate(
			Twitter twitter,
			string screen_name = null,
			Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(
				await twitter.Request(
					API.Method.POST,
					new Uri(API.Urls.Blocks_Create), query));
		}

		public static async Task<User> BlocksDestroy(
			Twitter twitter, 
			string screen_name = null,
			Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(
				await twitter.Request(
					API.Method.POST,
					new Uri(API.Urls.Blocks_Destroy), query));
		}
	}
}
