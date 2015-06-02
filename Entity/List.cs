using System;
using System.Threading.Tasks;

namespace Twitch.Entity
{
	/// <summary>
	/// リスト
	/// </summary>
	[Serializable]
	public class List : Response.List
	{
		public List()
			: base() { }

		public List(string source)
			: base(source) { }
	}
}
