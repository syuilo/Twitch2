using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Entity.Response
{
	/// <summary>
	/// DirectMessage情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class DirectMessage : TwitterResponse
	{
		/// <summary>
		/// 空のDirectMessageエンティティを初期化します。
		/// </summary>
		public DirectMessage()
			: base() { }

		/// <summary>
		/// データ ソースを与えてエンティティを初期化します。
		/// </summary>
		/// <param name="source">Twitterから送信されたデータ ソース</param>
		public DirectMessage(string source)
			: base(source)
		{
			this.CreatedAt = DateTime.ParseExact(this.Json["created_at"], DateTimeFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
			this.Entities = new Entities.Entities(this.Json["entities"].ToString());
			this.ID = (Int64)this.Json["id"];
			this.StringID = this.Json["id_str"];
			this.Text = this.Json["text"];
			this.Recipient = new User(this.Json["recipient"].ToString());
			this.RecipientID = (Int64)this.Json["recipient_id"];
			this.RecipientScreenName = this.Json["recipient_screen_name"];
			this.Sender = new User(this.Json["sender"].ToString());
			this.SenderID = (Int64)this.Json["sender_id"];
			this.SenderScreenName = this.Json["sender_screen_name"];
		}

		/// <summary>
		/// メッセージの作成日時を取得します。
		/// </summary>
		public DateTime CreatedAt
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
		/// メッセージIDを取得します。
		/// </summary>
		public Int64 ID
		{
			get;
			private set;
		}

		/// <summary>
		/// メッセージID(String)を取得します。
		/// </summary>
		public string StringID
		{
			get;
			private set;
		}

		/// <summary>
		/// メッセージの受信者を取得します。
		/// </summary>
		public User Recipient
		{
			get;
			private set;
		}

		/// <summary>
		/// メッセージの受信者のIDを取得します。
		/// </summary>
		public Int64 RecipientID
		{
			get;
			private set;
		}

		/// <summary>
		/// メッセージの受信者のScreenNameを取得します。
		/// </summary>
		public string RecipientScreenName
		{
			get;
			private set;
		}

		/// <summary>
		/// メッセージの送信者を取得します。
		/// </summary>
		public User Sender
		{
			get;
			private set;
		}

		/// <summary>
		/// メッセージの送信者のIDを取得します。
		/// </summary>
		public Int64 SenderID
		{
			get;
			private set;
		}

		/// <summary>
		/// メッセージの送信者のScreenNameを取得します。
		/// </summary>
		public string SenderScreenName
		{
			get;
			private set;
		}

		/// <summary>
		/// メッセージ本文を取得します。
		/// </summary>
		public string Text
		{
			get;
			private set;
		}
	}
}
