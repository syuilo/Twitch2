using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Entity.Response.Places
{
	[Serializable]
	public class Places : TwitterResponse
	{
		public Places()
			: base() { }

		public Places(string source)
			: base(source)
		{
			this.BoundingBox = (this.Json.IsDefined("bounding_box")) ? new BoundingBox(this.Json["bounding_box"].ToString()) : null;
			this.Country = this.Json["country"];
			this.CountryCode = this.Json["country_code"];
			this.FullName = this.Json["full_name"];
			this.ID = this.Json["id"];
			this.Name = this.Json["name"];
			this.PlaceType = this.Json["place_type"];
			this.Url = new Uri(this.Json["url"]);
		}

		/// <summary>
		/// 
		/// </summary>
		public BoundingBox BoundingBox
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string CountryCode
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
		/// 
		/// </summary>
		public string ID
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string PlaceType
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Uri Url
		{
			get;
			private set;
		}
	}
}
