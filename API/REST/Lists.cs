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
		public static async Task<List> ListsCreate(
			Twitter twitter, string name, string description, string mode = null)
		{
			var query = new Dictionary<string, string>();
			query["name"] = name;
			query["mode"] = mode;
			query["description"] = description;

			return new List(
				await twitter.Request(API.Method.POST, new Uri(API.Urls.Lists_Create), query));
		}

		[AuthenticationRequired]
		public static async Task<List> ListsDestroy(
			Twitter twitter, Int64? list_id = null, string slug = null, Int64? owner_id = null, string owner_screen_name = null)
		{
			var query = new Dictionary<string, string>();
			query["list_id"] = list_id.ToString();
			query["slug"] = slug;
			query["owner_id"] = owner_id.ToString();
			query["owner_screen_name"] = owner_screen_name;

			return new List(
				await twitter.Request(API.Method.POST, new Uri(API.Urls.Lists_Destroy), query));
		}

		[AuthenticationRequired]
		public static async void ListsMembersCreate(
			Twitter twitter, Int64? list_id = null, string slug = null, Int64? owner_id = null, string owner_screen_name = null, Int64? user_id = null, string screen_name = null)
		{
			var query = new Dictionary<string, string>();
			query["list_id"] = list_id.ToString();
			query["slug"] = slug;
			query["owner_id"] = owner_id.ToString();
			query["owner_screen_name"] = owner_screen_name;
			query["user_id"] = owner_id.ToString();
			query["screen_name"] = owner_screen_name;

			await
				twitter.Request(API.Method.POST, new Uri(API.Urls.Lists_Members_Create), query);
		}

		[AuthenticationRequired]
		public static async void ListsMembersDestroy(
			Twitter twitter, Int64? list_id = null, string slug = null, Int64? owner_id = null, string owner_screen_name = null, Int64? user_id = null, string screen_name = null)
		{
			var query = new Dictionary<string, string>();
			query["list_id"] = list_id.ToString();
			query["slug"] = slug;
			query["owner_id"] = owner_id.ToString();
			query["owner_screen_name"] = owner_screen_name;
			query["user_id"] = owner_id.ToString();
			query["screen_name"] = owner_screen_name;

			await
				twitter.Request(API.Method.POST, new Uri(API.Urls.Lists_Members_Destroy), query);
		}
	}
}
