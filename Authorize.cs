using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Twitch
{
	/// <summary>
	/// 一連のアカウント認証処理を行うクラスです。
	/// </summary>
	public class Authorize
	{
		/// <summary>
		/// アプリケーションのConsumerKey。
		/// </summary>
		private string ConsumerKey
		{
			get;
			set;
		}

		/// <summary>
		/// アプリケーションのConsumerSecret。
		/// </summary>
		private string ConsumerSecret
		{
			get;
			set;
		}

		/// <summary>
		/// RequestToken
		/// </summary>
		public string OAuthToken
		{
			get;
			private set;
		}

		/// <summary>
		/// RequestTokenSecret
		/// </summary>
		public string OAuthTokenSecret
		{
			get;
			private set;
		}

		/// <summary>
		/// Authorizeを初期化します。
		/// </summary>
		/// <param name="consumerKey">アプリケーションのConsumerKey</param>
		/// <param name="consumerSecret">アプリケーションのConsumerSecret</param>
		public Authorize(string consumerKey, string consumerSecret)
		{
			this.ConsumerKey = consumerKey;
			this.ConsumerSecret = consumerSecret;
		}

		/// <summary>
		/// RequestToken, RequestTokenSecretを取得します。
		/// </summary>
		/// <returns>正常に取得できた場合はtrueを、それ以外の場合はfalseを返します。</returns>
		public async Task<bool> GetRequestToken()
		{
			var tw = new Twitter(this.ConsumerKey, this.ConsumerSecret);

			//try
			//{
			string res = await tw.OauthRequestToken();

			if (!string.IsNullOrEmpty(res))
			{
				this.OAuthToken = Utility.AnalyzeUrlQuery.Analyze(res, "oauth_token");
				this.OAuthTokenSecret = Utility.AnalyzeUrlQuery.Analyze(res, "oauth_token_secret");

				return true;
			}
			else
				return false;
			//}
			//catch
			//{
			//    return false;
			//}
		}

		/// <summary>
		/// Authorize URLを取得します。
		/// </summary>
		/// <returns>URL</returns>
		public Uri GetAuthorizeUrl()
		{
			if (this.OAuthToken != null)
				return new Uri(API.Urls.Oauth_Authorize + "?oauth_token=" + this.OAuthToken);
			else
				throw new ApplicationException("リクエスト トークンが設定されていません。GetRequestToken を呼び出してください。");
		}

		/// <summary>
		/// Webのアプリケーション連携認証フォームを既定のウェブ ブラウザーで表示します。
		/// </summary>
		public void ShowAuthorizeBrowser()
		{
			Uri url = this.GetAuthorizeUrl();

			System.Diagnostics.Process.Start(url.ToString());
		}


		/// <summary>
		/// xAuthによってAccessToken,AccessTokenSecretを取得します。これはxAuthが許可されたトークンでのみ使用する事が出来ます。
		/// </summary>
		/// <param name="ScreenName">ユーザー名</param>
		/// <param name="Password">パスワード</param>
		/// <returns>TwitterContext。失敗した場合はNull</returns>
		public async Task<Twitter> GetAccessTokenFromXAuth(string ScreenName, string Password)
		{
			var tw = new Twitter(this.ConsumerKey, this.ConsumerSecret);
			string res = await tw.OauthAccessToken(ScreenName, Password);

			if (!string.IsNullOrEmpty(res))
			{
				string access_token = Utility.AnalyzeUrlQuery.Analyze(res, "oauth_token");
				string access_token_secret = Utility.AnalyzeUrlQuery.Analyze(res, "oauth_token_secret");

				return new Twitter(this.ConsumerKey, this.ConsumerSecret, access_token, access_token_secret);
			}
			else
				return null;
		}

		/// <summary>
		/// PINコードからAccessToken,AccessTokenSecretを取得します。
		/// </summary>
		/// <param name="PIN">PINコード</param>
		/// <returns>TwitterContext。失敗した場合はNull</returns>
		public async Task<Twitter> GetAccessTokenFromPinCode(string PIN)
		{
			var tw = new Twitter(this.ConsumerKey, this.ConsumerSecret, this.OAuthToken, this.OAuthTokenSecret);
			string res = await tw.OauthAccessToken(PIN);
			Console.WriteLine(res);

			if (!string.IsNullOrEmpty(res))
			{
				string access_token = Utility.AnalyzeUrlQuery.Analyze(res, "oauth_token");
				string access_token_secret = Utility.AnalyzeUrlQuery.Analyze(res, "oauth_token_secret");
				string screenName = Utility.AnalyzeUrlQuery.Analyze(res, "screen_name");
				var id = Int64.Parse(Utility.AnalyzeUrlQuery.Analyze(res, "user_id"));

				return new Twitter(this.ConsumerKey, this.ConsumerSecret, access_token, access_token_secret, screenName, id);
			}
			else
				return null;
		}
	}
}
