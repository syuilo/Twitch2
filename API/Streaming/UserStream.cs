using System;
using Twitch.API;

namespace Twitch.Streaming
{
	/// <summary>
	/// UserStreamとの接続を行うクラスです。
	/// </summary>
	public class UserStream : StreamingBase
	{
		#region Events

		#region BlockedEvent
		public delegate void BlockedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// ユーザーをブロックしました。
		/// </summary>
		public event BlockedEventHandler Blocked;

		/// <summary>
		/// Blocked イベントを発行します。
		/// </summary>
		protected virtual void OnBlocked(StreamEventEventArgs e)
		{
			if (Blocked != null)
				Blocked(this, e);
		}
		#endregion

		#region UnBlockedEvent
		public delegate void UnBlockedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// ユーザーのブロックを解除しました。
		/// </summary>
		public event UnBlockedEventHandler UnBlocked;

		/// <summary>
		/// UnBlocked イベントを発行します。
		/// </summary>
		protected virtual void OnUnBlocked(StreamEventEventArgs e)
		{
			if (UnBlocked != null)
				UnBlocked(this, e);
		}
		#endregion

		#region FavoritedEvent
		public delegate void FavoritedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// ツイートがお気に入りに登録されました。
		/// </summary>
		public event FavoritedEventHandler Favorited;

		/// <summary>
		/// Favorited イベントを発行します。
		/// </summary>
		protected virtual void OnFavorited(StreamEventEventArgs e)
		{
			if (Favorited != null)
				Favorited(this, e);
		}
		#endregion

		#region UnFavoritedEvent
		public delegate void UnFavoritedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// ツイートがお気に入りから解除されました。
		/// </summary>
		public event UnFavoritedEventHandler UnFavorited;

		/// <summary>
		/// UnFavorited イベントを発行します。
		/// </summary>
		protected virtual void OnUnFavorited(StreamEventEventArgs e)
		{
			if (UnFavorited != null)
				UnFavorited(this, e);
		}
		#endregion

		#region FollowedEvent
		public delegate void FollowedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// フォローしました。
		/// </summary>
		public event FollowedEventHandler Followed;

		/// <summary>
		/// Followed イベントを発行します。
		/// </summary>
		protected virtual void OnFollowed(StreamEventEventArgs e)
		{
			if (Followed != null)
				Followed(this, e);
		}
		#endregion

		#region UnFollowedEvent
		public delegate void UnFollowedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// フォローが解除されました。
		/// </summary>
		public event UnFollowedEventHandler UnFollowed;

		/// <summary>
		/// UnFollowed イベントを発行します。
		/// </summary>
		protected virtual void OnUnFollowed(StreamEventEventArgs e)
		{
			if (UnFollowed != null)
				UnFollowed(this, e);
		}
		#endregion

		#region ListCreatedEvent
		public delegate void ListCreatedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// リストが作成されました。
		/// </summary>
		public event ListCreatedEventHandler ListCreated;

		/// <summary>
		/// ListCreated イベントを発行します。
		/// </summary>
		protected virtual void OnListCreated(StreamEventEventArgs e)
		{
			if (ListCreated != null)
				ListCreated(this, e);
		}
		#endregion

		#region ListDestoryedEvent
		public delegate void ListDestoryedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// リストが削除されました。
		/// </summary>
		public event ListDestoryedEventHandler ListDestoryed;

		/// <summary>
		/// ListDestoryed イベントを発行します。
		/// </summary>
		protected virtual void OnListDestoryed(StreamEventEventArgs e)
		{
			if (ListDestoryed != null)
				ListDestoryed(this, e);
		}
		#endregion

		#region ListUpdatedEvent
		public delegate void ListUpdatedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// リストが編集されました。(リストが更新されました。)
		/// </summary>
		public event ListUpdatedEventHandler ListUpdated;

		/// <summary>
		/// ListUpdated イベントを発行します。
		/// </summary>
		protected virtual void OnListUpdated(StreamEventEventArgs e)
		{
			if (ListUpdated != null)
				ListUpdated(this, e);
		}
		#endregion

		#region ListMemberAddedEvent
		public delegate void ListMemberAddedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// リストにメンバーが追加されました。
		/// </summary>
		public event ListMemberAddedEventHandler ListMemberAdded;

		/// <summary>
		/// ListMemberAdded イベントを発行します。
		/// </summary>
		protected virtual void OnListMemberAdded(StreamEventEventArgs e)
		{
			if (ListMemberAdded != null)
				ListMemberAdded(this, e);
		}
		#endregion

		#region ListMemberRemovedEvent
		public delegate void ListMemberRemovedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// リストからメンバーが削除されました。
		/// </summary>
		public event ListMemberRemovedEventHandler ListMemberRemoved;

		/// <summary>
		/// ListMemberRemoved イベントを発行します。
		/// </summary>
		protected virtual void OnListMemberRemoved(StreamEventEventArgs e)
		{
			if (ListMemberRemoved != null)
				ListMemberRemoved(this, e);
		}
		#endregion

		#region ListUserSubscribedEvent
		public delegate void ListUserSubscribedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// リストが保存されました。
		/// </summary>
		public event ListUserSubscribedEventHandler ListUserSubscribed;

		/// <summary>
		/// ListUserSubscribed イベントを発行します。
		/// </summary>
		protected virtual void OnListUserSubscribed(StreamEventEventArgs e)
		{
			if (ListUserSubscribed != null)
				ListUserSubscribed(this, e);
		}
		#endregion

		#region ListUserUnSubscribedEvent
		public delegate void ListUserUnSubscribedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// リストの保存を解除されました。
		/// </summary>
		public event ListUserUnSubscribedEventHandler ListUserUnSubscribed;

		/// <summary>
		/// ListUserUnSubscribed イベントを発行します。
		/// </summary>
		protected virtual void OnListUserUnSubscribed(StreamEventEventArgs e)
		{
			if (ListUserUnSubscribed != null)
				ListUserUnSubscribed(this, e);
		}
		#endregion

		#region UserUpdatedEvent
		public delegate void UserUpdatedEventHandler(object sender, StreamEventEventArgs e);

		/// <summary>
		/// ユーザーのプロフィールが更新されました。<para />
		/// ユーザーのツイートの公開設定が変更されました。
		/// </summary>
		public event UserUpdatedEventHandler UserUpdated;

		/// <summary>
		/// UserUpdated イベントを発行します。
		/// </summary>
		protected virtual void OnUserUpdated(StreamEventEventArgs e)
		{
			if (UserUpdated != null)
				UserUpdated(this, e);
		}
		#endregion

		#region StatusUpdatedEvent
		public delegate void StatusUpdatedEventHandler(object sender, StatusUpdatedEventArgs e);

		/// <summary>
		/// タイムラインにツイートが投稿された際に発生します。
		/// </summary>
		public event StatusUpdatedEventHandler StatusUpdated;

		/// <summary>
		/// StatusUpdated イベントを発行します。
		/// </summary>
		protected virtual void OnStatusUpdated(StatusUpdatedEventArgs e)
		{
			if (StatusUpdated != null)
				StatusUpdated(this, e);
		}
		#endregion

		#region SendFriendsListsMessagedEvent
		public delegate void SendFriendsListsMessagedEventHandler(object sender, FriendsListsEventArgs e);

		/// <summary>
		/// 接続を開始した際、FriendsListsが受信されました。
		/// </summary>
		public event SendFriendsListsMessagedEventHandler SendFriendsListsMessaged;

		/// <summary>
		/// SendFriendsListsMessaged イベントを発行します。
		/// </summary>
		protected virtual void OnSendFriendsListsMessaged(FriendsListsEventArgs e)
		{
			if (SendFriendsListsMessaged != null)
				SendFriendsListsMessaged(this, e);
		}
		#endregion

		#region RetweetedEvent
		//public delegate void RetweetedEventHandler(User target, User source, string createdAt);

		///// <summary>
		///// ツイートがリツイートされました。
		///// </summary>
		//public event RetweetedEventHandler Retweeted = delegate { };
		//#endregion

		//#region UnRetweetedEvent
		//public delegate void UnRetweetedEventHandler(User target, User source, string createdAt);

		///// <summary>
		///// ツイートのリツイートが取り消されました。
		///// </summary>
		//public event UnRetweetedEventHandler UnRetweeted = delegate { };
		#endregion

		#endregion

		/// <summary>
		/// UserStreamの接続開始時に送信される、FriendsLists メッセージを受け取るかどうかを示す System.Boolean 値を取得または設定します。
		/// </summary>
		public bool IsReceiveFriendsList
		{
			get;
			set;
		}

		/// <summary>
		/// UserStreamを初期化します。
		/// </summary>
		public UserStream(Twitter twitterContext)
			: base(twitterContext)
		{
			this.StreamMessaged += new StreamMessagedEventHandler(StreamingCallback);

			this.Url = "https://userstream.twitter.com/1.1/user.json";
			this.Host = "userstream.twitter.com";
			this.Method = Method.GET;
		}

		/// <summary>
		/// イベントの振り分けを行います。
		/// </summary>
		private void StreamingCallback(object sender, StreamEventArgs e)
		{
			var json = Twitch.Utility.DynamicJson.Parse(e.Data);

			#region Filing

			// Events
			if (json.IsDefined("event"))
			{
				#region Events
				switch ((string)json["event"])
				{
					case "block":
						this.OnBlocked(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "unblock":
						this.OnUnBlocked(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "favorite":
						this.OnFavorited(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = new Twitter.Status(json["target_object"].ToString()),
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "unfavorite":
						this.OnUnFavorited(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = new Twitter.Status(json["target_object"].ToString()),
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "follow":
						this.OnFollowed(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "unfollow":
						this.OnUnFollowed(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "list_created":
						this.OnListCreated(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "list_destroyed":
						this.OnListDestoryed(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "list_updated":
						this.OnListUpdated(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "list_member_added":
						this.OnListMemberAdded(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "list_member_removed":
						this.OnListMemberRemoved(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "list_user_subscribed":
						this.OnListUserSubscribed(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "list_user_unsubscribed":
						this.OnListUserUnSubscribed(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					case "user_update":
						this.OnUserUpdated(
							new StreamEventEventArgs
							{
								Target = new Twitter.User(json["target"].ToString()),
								Source = new Twitter.User(json["source"].ToString()),
								Event = json["event"],
								TargetObject = null,
								CreatedAt = json["created_at"],
							}
						);
						break;

					default:
						if (!this.IsTolerance)
							throw new ApplicationException(
								"不明なイベントが発行されました。\"" + (string)json["event"] + "\"" + Environment.NewLine +
								"この種の予期しないメッセージに対して例外を発生させない場合は、このStreamの IsTolerance プロパティを true に設定してください。");
						break;
				}
				#endregion
			}
			// Friends lists
			else if (json.IsDefined("friends"))
			{
				if (this.IsReceiveFriendsList)
					this.OnSendFriendsListsMessaged(
						new FriendsListsEventArgs
						{
							IntList = (Int64[])json
						}
					);
				else
					return;
			}
			// Friends lists (str)
			else if (json.IsDefined("friends_str"))
			{
				if (this.IsReceiveFriendsList)
					this.OnSendFriendsListsMessaged(
						new FriendsListsEventArgs
						{
							StringList = json
						}
					);
				else
					return;
			}
			// Status
			else
			{
				Twitter.Status status;

				try
				{
					status = new Twitter.Status(json.ToString());
				}
				catch
				{
					if (!this.IsTolerance)
						throw new ApplicationException(
							"不明なメッセージが発行されました。\"" + json.ToString() + "\"" + Environment.NewLine +
							"この種の予期しないメッセージに対して例外を発生させない場合は、このStreamの IsTolerance プロパティを true に設定してください。");
					return;
				}

				this.OnStatusUpdated(
					new StatusUpdatedEventArgs
					{
						Status = status
					}
				);
			}

			#endregion
		}
	}
}
