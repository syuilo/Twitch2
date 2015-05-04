using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<string> OauthAuthorize()
		{
			return await this.Request(API.Method.GET, new Uri(API.Urls.Oauth_Authorize));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="oauthVerifier"></param>
		/// <returns></returns>
		public async Task<string> OauthAccessToken(string oauthVerifier)
		{
			var query = new StringDictionary();
			query["oauth_verifier"] = oauthVerifier;

			return await this.Request(API.Method.POST, new Uri(API.Urls.Oauth_AccessToken), query);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="xAuthUsername"></param>
		/// <param name="xAuthPassword"></param>
		/// <returns></returns>
		public async Task<string> OauthAccessToken(string xAuthUsername, string xAuthPassword)
		{
			var query = new StringDictionary();
			query["x_auth_username"] = xAuthUsername;
			query["x_auth_password"] = xAuthPassword;
			query["x_auth_mode"] = "client_auth";

			return await this.Request(API.Method.POST, new Uri(API.Urls.Oauth_AccessToken), query);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<string> OauthRequestToken()
		{
			return await this.Request(API.Method.POST, new Uri(API.Urls.Oauth_RequestToken));
		}
	}
}
