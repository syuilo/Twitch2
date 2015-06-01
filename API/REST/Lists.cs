using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Twitch.API
{
	public partial class Rest
	{
		[AuthenticationRequired]
		public async Task<string> ListsCreate(
			string name, string description, string mode = null)
		{
			var query = new Dictionary<string, string>();
			query["name"] = name;
			query["mode"] = mode;
			query["description"] = description;

			return await
				this.Request(API.Method.POST, new Uri(API.Urls.Lists_Create), query);
		}

		[AuthenticationRequired]
		public async Task<string> ListsDestroy(
			string slug, string owner_screen_name)
		{
			var query = new Dictionary<string, string>();
			query["slug"] = slug;
			query["owner_screen_name"] = owner_screen_name;

			return await
				this.Request(API.Method.POST, new Uri(API.Urls.Lists_Destroy), query);
		}

		[AuthenticationRequired]
		public async Task<string> ListsMembersCreate(
			string slug, string screen_name, string owner_screen_name)
		{
			var query = new Dictionary<string, string>();
			query["slug"] = slug;
			query["screen_name"] = screen_name;
			query["owner_screen_name"] = owner_screen_name;

			return await
				this.Request(API.Method.POST, new Uri(API.Urls.Lists_Members_Create), query);
		}

		[AuthenticationRequired]
		public async Task<string> ListsMembersDestroy(
			string slug, string screen_name, string owner_screen_name)
		{
			var query = new Dictionary<string, string>();
			query["slug"] = slug;
			query["screen_name"] = screen_name;
			query["owner_screen_name"] = owner_screen_name;

			return await
				this.Request(API.Method.POST, new Uri(API.Urls.Lists_Members_Destroy), query);
		}
	}
}
