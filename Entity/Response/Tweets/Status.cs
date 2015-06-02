using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Entity.Response.Tweets
{
	/// <summary>
	/// Status情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class Status : TwitterResponse
	{
		/// <summary>
		/// 空のStatusエンティティを初期化します。
		/// </summary>
		public Status()
			: base() { }

		/// <summary>
		/// データ ソースを与えてエンティティを初期化します。
		/// </summary>
		/// <param name="source">Twitterから送信されたデータ ソース</param>
		public Status(string source)
			: base(source)
		{
			//this.Contributors = new Entities(json["contributors"].ToString());
			//this.Coordinates = new Coordinates(json["coordinates"].ToString());
			this.IsFavorited = this.Json["favorited"];
			this.IsTruncated = this.Json["truncated"];
			this.CreatedAt = DateTime.ParseExact(this.Json["created_at"], DateTimeFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
			this.StringID = this.Json["id_str"];
			this.Entities = new Entities.Entities(this.Json["entities"].ToString());
			this.Text = this.Json["text"];
			this.RetweetCount = this.Json["retweet_count"];
			this.FavoriteCount = this.Json["favorite_count"];
			this.InReplyToStatusIDstr = this.Json["in_reply_to_status_id_str"];
			this.ID = (Int64)this.Json["id"];
			//this.Geo = (this.Json["geo"] != null) ? new Geo(this.Json["geo"].ToString()) : null;
			this.IsRetweeted = this.Json["retweeted"];
			this.IsPossiblySensitive = (this.Json.IsDefined("possibly_sensitive")) ? this.Json["possibly_sensitive"] : null;
			this.InReplyToUserID = (Int64?)this.Json["in_reply_to_user_id"];
			this.Place = (this.Json["place"] != null) ? new Places.Places(this.Json["place"].ToString()) : null;
			this.User = (this.Json.IsDefined("user")) ? new User(this.Json["user"].ToString()) : null;
			this.InReplyToScreenName = this.Json["in_reply_to_screen_name"];
			this.Source = this.Json["source"];
			this.InReplyToStatusID = this.Json["in_reply_to_status_id"];
		}

		/// <summary>
		/// 
		/// </summary>
		[Obsolete("Future/beta home for status annotations.")]
		public Annotations Annotations
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Contributors[] Contributors
		{
			get;
			private set;
		}

		/// <summary>
		/// 緯度・経度を取得します。
		/// </summary>
		public Coordinates Coordinates
		{
			get;
			private set;
		}

		/// <summary>
		/// お気に入りに登録しているかどうかを表す System.Boolean 値を取得します。
		/// </summary>
		public bool IsFavorited
		{
			get;
			private set;
		}

		/// <summary>
		/// このツイートは省略されています。
		/// </summary>
		public bool IsTruncated
		{
			get;
			private set;
		}

		/// <summary>
		/// 投稿日時を取得します。
		/// </summary>
		public DateTime CreatedAt
		{
			get;
			private set;
		}

		/// <summary>
		/// ツイートID(String)を取得します。
		/// </summary>
		public string StringID
		{
			get;
			private set;
		}

		/// <summary>
		/// エンティティを取得します。
		/// </summary>
		public Entities.Entities Entities
		{
			get;
			private set;
		}

		/// <summary>
		/// ツイート本文を取得します。
		/// </summary>
		public string Text
		{
			get;
			private set;
		}

		/// <summary>
		/// リツイートされた数を取得します。
		/// </summary>
		public double RetweetCount
		{
			get;
			private set;
		}

		/// <summary>
		/// お気に入りに登録されている数を取得します。
		/// </summary>
		public double FavoriteCount
		{
			get;
			private set;
		}

		/// <summary>
		/// 返信元になるツイートのIDを取得します。<para />
		/// このツイートが返信ではない場合は Null を返します。
		/// </summary>
		public string InReplyToStatusIDstr
		{
			get;
			private set;
		}

		/// <summary>
		/// ツイートID(Int64)を取得します。
		/// </summary>
		public Int64 ID
		{
			get;
			private set;
		}

		/// <summary>
		/// 位置情報を取得します。
		/// </summary>
		public Geo Geo
		{
			get;
			private set;
		}

		/// <summary>
		/// リツイートしているかどうかを表す System.Boolean 値を取得します。
		/// </summary>
		public bool IsRetweeted
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsPossiblySensitive
		{
			get;
			private set;
		}

		/// <summary>
		/// 返信元になるツイートのユーザーのID
		/// (このツイートが返信ではない場合はNull)
		/// </summary>
		public Int64? InReplyToUserID
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Places.Places Place
		{
			get;
			private set;
		}

		/// <summary>
		/// ツイートを作成したユーザーを取得します。
		/// </summary>
		public User User
		{
			get;
			private set;
		}

		/// <summary>
		/// 返信元になるツイートのユーザーのScreenName
		/// (このツイートが返信ではない場合はNull)
		/// </summary>
		public string InReplyToScreenName
		{
			get;
			private set;
		}

		/// <summary>
		/// Via
		/// </summary>
		public string Source
		{
			get;
			private set;
		}



		/// <summary>
		/// 返信元になるツイートのID
		/// (このツイートが返信ではない場合はNull)
		/// </summary>
		public double? InReplyToStatusID
		{
			get;
			private set;
		}
	}
}
