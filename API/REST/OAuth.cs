using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Twitch.API
{
	public partial class Rest
	{
		public static async Task<string> OauthAuthorize(Twitter twitter)
		{
			return await
				twitter.Request(API.Method.GET, new Uri(API.Urls.Oauth_Authorize));
		}

		public static async Task<string> OauthAccessToken(
			Twitter twitter, string oauthVerifier)
		{
			var query = new Dictionary<string, string>();
			query["oauth_verifier"] = oauthVerifier;

			return await
				twitter.Request(API.Method.POST, new Uri(API.Urls.Oauth_AccessToken), query);
		}

		public static async Task<string> OauthAccessToken(
			Twitter twitter,
			string xAuthUsername,
			string xAuthPassword)
		{
			var query = new Dictionary<string, string>();
			query["x_auth_username"] = xAuthUsername;
			query["x_auth_password"] = xAuthPassword;
			query["x_auth_mode"] = "client_auth";

			return await
				twitter.Request(API.Method.POST, new Uri(API.Urls.Oauth_AccessToken), query);
		}

		public static async Task<string> OauthRequestToken(Twitter twitter)
		{
			return await
				twitter.Request(API.Method.POST, new Uri(API.Urls.Oauth_RequestToken));
		}
	}
}
