﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch
{
	/// <summary>
	/// Twitterとのやりとりを行うクラス(Twitterオブジェクト)です。
	/// ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret を格納し、各種APIへのアクセスを可能にします。
	/// </summary>
	public partial class Twitter
	{
		#region Properties

		/// <summary>
		/// アプリケーションの ConsumerKey を取得または設定します。
		/// </summary>
		public string ConsumerKey
		{
			get;
			set;
		}

		/// <summary>
		/// アプリケーションの ConsumerSecret を取得または設定します。
		/// </summary>
		public string ConsumerSecret
		{
			get;
			set;
		}

		/// <summary>
		/// ユーザーの AccessToken を取得または設定します。
		/// </summary>
		public string AccessToken
		{
			get;
			set;
		}

		/// <summary>
		/// ユーザーの AccessTokenSecret を取得または設定します。
		/// </summary>
		public string AccessTokenSecret
		{
			get;
			set;
		}

		/// <summary>
		/// 認証されたユーザーの ScreenName
		/// </summary>
		public string ScreenName
		{
			get;
			private set;
		}

		/// <summary>
		/// 認証されたユーザーの ID
		/// </summary>
		public Int64 UserID
		{
			get;
			private set;
		}

		/// <summary>
		/// このTwitterオブジェクトにAccessTokenおよびAccessTokenSecretが設定されているかどうかを取得します。
		/// </summary>
		public bool IsAuthorized
		{
			get
			{
				return !(String.IsNullOrEmpty(this.AccessToken) || String.IsNullOrEmpty(this.AccessTokenSecret));
			}
			private set;
		}

		private Authorize Auth
		{
			get;
			set;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Twitterオブジェクトを初期化します。
		/// </summary>
		/// <param name="consumerKey">アプリケーションの ConsumerKey</param>
		/// <param name="consumerSecret">アプリケーションの ConsumerSecret</param>
		/// <param name="accessToken">ユーザーの AccessToken</param>
		/// <param name="accessTokenSecret">ユーザーの AccessTokenSecret</param>
		/// <param name="screenName">ユーザーの ScreenName</param>
		/// <param name="userID">ユーザーの ID</param>
		public Twitter(
				string consumerKey,
				string consumerSecret,
				string accessToken,
				string accessTokenSecret,
				string screenName,
				Int64 userID)
		{
			this.ConsumerKey = consumerKey;
			this.ConsumerSecret = consumerSecret;
			this.AccessToken = accessToken;
			this.AccessTokenSecret = accessTokenSecret;
			this.ScreenName = screenName;
			this.UserID = userID;
		}

		/// <summary>
		/// Twitterオブジェクトを初期化します。
		/// </summary>
		/// <param name="consumerKey">アプリケーションの ConsumerKey</param>
		/// <param name="consumerSecret">アプリケーションの ConsumerSecret</param>
		/// <param name="accessToken">ユーザーの AccessToken</param>
		/// <param name="accessTokenSecret">ユーザーの AccessTokenSecret</param>
		public Twitter(
				string consumerKey,
				string consumerSecret,
				string accessToken,
				string accessTokenSecret)
		{
			this.ConsumerKey = consumerKey;
			this.ConsumerSecret = consumerSecret;
			this.AccessToken = accessToken;
			this.AccessTokenSecret = accessTokenSecret;
		}

		/// <summary>
		/// Twitterオブジェクトを初期化します。
		/// </summary>
		/// <param name="consumerKey">アプリケーションの ConsumerKey</param>
		/// <param name="consumerSecret">アプリケーションの ConsumerSecret</param>
		public Twitter(
				string consumerKey,
				string consumerSecret)
		{
			this.ConsumerKey = consumerKey;
			this.ConsumerSecret = consumerSecret;
		}

		/// <summary>
		/// Twitterオブジェクトを初期化します。
		/// </summary>
		/// <param name="twitter">Twitterオブジェクト</param>
		public Twitter(Twitter twitter)
		{
			this.ConsumerKey = twitter.ConsumerKey;
			this.ConsumerSecret = twitter.ConsumerSecret;
			this.AccessToken = twitter.AccessToken;
			this.AccessTokenSecret = twitter.AccessTokenSecret;
		}

		#endregion

		/// <summary>
		/// 認証されたユーザーでTwitter APIへリクエストを送信し、非同期でレスポンスを取得します。
		/// </summary>
		/// <param name="method">リクエスト メソッド</param>
		/// <param name="url">APIのURL。</param>
		/// <param name="parameter">リクエストのパラメーター。</param>
		/// <returns>APIから返された値(レスポンス)</returns>
		public async Task<string> Request(
			API.Method method, System.Uri url, StringDictionary parameter = null)
		{
			return await new TwitterRequest(
				this, method, url, parameter).Request();
		}

		/// <summary>
		/// このTwitterオブジェクトのConsumerKey/ConsumerSecretに関連付けられたアプリケーションの連携認証フォームを規定のウェブ ブラウザで表示します。
		/// </summary>
		public async void Authorize()
		{
			this.Auth = new Authorize(this.ConsumerKey, this.ConsumerSecret);
			await this.Auth.GetRequestToken();
			this.Auth.ShowAuthorizeBrowser();
		}

		/// <summary>
		/// 認証フォームで得られたPINコードを基に連携されたユーザーのTwitterオブジェクトを取得します。
		/// </summary>
		/// <param name="pin">PINコード</param>
		/// <returns>連携されたユーザーのTwitterオブジェクト</returns>
		public async Task<Twitter> AuthorizePin(string pin)
		{
			return await this.Auth.GetAccessTokenFromPinCode(pin);
		}
	}
}
