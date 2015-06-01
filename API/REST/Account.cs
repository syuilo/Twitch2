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
		public static async Task<User> UpdateProfile(
			Twitter twitter,
			string name = null,
			Uri url = null,
			string location = null,
			string description = null)
		{
			var query = new Dictionary<string, string>();
			if (name != null) query["name"] = name;
			if (url != null) query["url"] = url.ToString();
			if (location != null) query["location"] = location;
			if (description != null) query["description"] = description;

			return new User(await twitter.Request(API.Method.POST, new Uri(API.Urls.Account_UpdateProfile), query));
		}

		[AuthenticationRequired]
		public static async Task<User> UpdateProfileImage(
			Twitter twitter,
			string image)
		{
			var query = new Dictionary<string, string>();
			query["image"] = image;

			return new User(await twitter.Request(API.Method.POST, new Uri(API.Urls.Account_UpdateProfileImage), query));
		}
	}
}
