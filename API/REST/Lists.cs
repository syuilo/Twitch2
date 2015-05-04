using System;
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
		public async Task<string> Create(string name, string description, string mode = null)
		{
			var query = new StringDictionary();
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
		public async Task<string> Destroy(string slug, string owner_screen_name)
		{
			var query = new StringDictionary();
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
		public async Task<string> MembersCreate(string slug, string screen_name, string owner_screen_name)
		{
			var query = new StringDictionary();
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
		public async Task<string> MembersDestroy(string slug, string screen_name, string owner_screen_name)
		{
			var query = new StringDictionary();
			query["slug"] = slug;
			query["screen_name"] = screen_name;
			query["owner_screen_name"] = owner_screen_name;

			return await this.Request(API.Method.POST, new Uri(API.Urls.Lists_Members_Destroy), query);
		}
	}
}
