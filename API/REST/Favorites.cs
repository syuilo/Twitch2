using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch.API
{
	public partial class Rest
	{
		[AuthenticationRequired]
		public static async Task<Status> FavoritesCreate(
			Twitter twitter,
			Int64 id)
		{
			var query = new Dictionary<string, string>();
			query["id"] = id.ToString();

			string res = await twitter.Request(API.Method.POST, new Uri(API.Urls.Favorites_Create), query);
			return res != null ? new Status(res) : null;
		}

		[AuthenticationRequired]
		public static async Task<Status> FavoritesDestroy(
			Twitter twitter, 
			Int64 id)
		{
			var query = new Dictionary<string, string>();
			query["id"] = id.ToString();

			string res = await twitter.Request(API.Method.POST, new Uri(API.Urls.Favorites_Destroy), query);
			return res != null ? new Status(res) : null;
		}
	}
}
