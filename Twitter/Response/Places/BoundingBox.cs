using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Response.Places
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class BoundingBox : TwitterResponse
	{
		public BoundingBox()
			: base() { }

		public BoundingBox(string source)
			: base(source)
		{
			this.Coordinates = this.Json["coordinates"];
			this.Type = this.Json["type"];
		}

		/// <summary>
		/// (機械翻訳)このバウンディングボックスが関連する場所エンティティを含むことになるボックスを定義する経度と緯度一連の点。
		/// 各ポイントは、[経度、緯度]の形で配列です。
		/// ポイントは、バウンディングボックスあたりの配列にグループ化されています。
		/// バウンディングボックスアレイは、ポリゴンの表記と互換性があるように一つの追加配列内にラップされます。
		/// </summary>
		public float[][][] Coordinates
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			get;
			private set;
		}
	}
}
