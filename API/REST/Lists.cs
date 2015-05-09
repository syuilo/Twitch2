using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// リストを作成します。
		/// </summary>
		/// <param name="name">リスト名。</param>
		/// <param name="mode">リストの公開状態。 public または private のいずれかを指定します。nullまたは指定しなかった場合はpublic(公開)になります。</param>
		/// <param name="description">リストの説明。</param>
		/// <returns></returns>
		public async Task<string> ListsCreate(string name, string description, string mode = null)
		{
			var query = new Dictionary<string, string>();
			query["name"] = name;
			query["mode"] = mode;
			query["description"] = description;

			return await this.Request(API.Method.POST, new Uri(API.Urls.Lists_Create), query);
		}

		/// <summary>
		/// リストを削除します。
		/// </summary>
		/// <param name="slug"></param>
		/// <param name="owner_screen_name"></param>
		/// <returns></returns>
		public async Task<string> ListsDestroy(string slug, string owner_screen_name)
		{
			var query = new Dictionary<string, string>();
			query["slug"] = slug;
			query["owner_screen_name"] = owner_screen_name;

			return await this.Request(API.Method.POST, new Uri(API.Urls.Lists_Destroy), query);
		}

		/// <summary>
		/// リストにメンバーを追加します。
		/// </summary>
		/// <param name="slug"></param>
		/// <param name="screen_name"></param>
		/// <param name="owner_screen_name"></param>
		/// <returns></returns>
		public async Task<string> ListsMembersCreate(string slug, string screen_name, string owner_screen_name)
		{
			var query = new Dictionary<string, string>();
			query["slug"] = slug;
			query["screen_name"] = screen_name;
			query["owner_screen_name"] = owner_screen_name;

			return await this.Request(API.Method.POST, new Uri(API.Urls.Lists_Members_Create), query);
		}

		/// <summary>
		/// リストからメンバーを削除します。
		/// </summary>
		/// <param name="slug"></param>
		/// <param name="screen_name"></param>
		/// <param name="owner_screen_name"></param>
		/// <returns></returns>
		public async Task<string> ListsMembersDestroy(string slug, string screen_name, string owner_screen_name)
		{
			var query = new Dictionary<string, string>();
			query["slug"] = slug;
			query["screen_name"] = screen_name;
			query["owner_screen_name"] = owner_screen_name;

			return await this.Request(API.Method.POST, new Uri(API.Urls.Lists_Members_Destroy), query);
		}
	}
}
