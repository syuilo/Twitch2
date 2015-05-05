using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Twitch.Entity.Response
{
	/// <summary>
	/// List情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class List : TwitterResponse
	{
		public List()
			: base() { }

		/// <summary>
		/// Listを初期化します。
		/// </summary>
		/// <param name="source">Jsonソース</param>
		public List(string source)
			: base(source)
		{
			this.Name = this.Json["name"];
			this.CreatedAt = DateTime.ParseExact(this.Json["created_at"], DateTimeFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
			this.StringID = this.Json["id_str"];
			this.ID = (Int64)this.Json["id"];
			this.Description = this.Json["description"];
		}

		/// <summary>
		/// リストの作成日時を取得します。
		/// </summary>
		public DateTime CreatedAt
		{
			get;
			private set;
		}

		/// <summary>
		/// リストの説明を取得します。
		/// </summary>
		public string Description
		{
			get;
			private set;
		}

		/// <summary>
		/// リストを保存しているかどうかを表す System.Boolean 値を取得します。
		/// </summary>
		public bool Following
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string FullName
		{
			get;
			private set;
		}

		/// <summary>
		/// IDを取得します。
		/// </summary>
		public Int64 ID
		{
			get;
			private set;
		}

		/// <summary>
		///リストのメンバー数を取得します。
		/// </summary>
		public double MemberCount
		{
			get;
			private set;
		}

		/// <summary>
		/// リストの公開状態を取得します。
		/// </summary>
		public ListMode Mode
		{
			get;
			private set;
		}

		/// <summary>
		/// リスト名を取得します。
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Slug
		{
			get;
			private set;
		}

		/// <summary>
		/// IDを取得します。
		/// </summary>
		public String StringID
		{
			get;
			private set;
		}

		/// <summary>
		///リストを保存しているユーザーの数を取得します。
		/// </summary>
		public double SubscriberCount
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Uri
		{
			get;
			private set;
		}

		/// <summary>
		/// リストを作成したユーザーを取得します。
		/// </summary>
		public User User
		{
			get;
			private set;
		}
	}
}
