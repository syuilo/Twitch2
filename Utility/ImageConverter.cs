using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Utility
{
	public static class ImageConverter
	{
		public static string ToBase64String(string imagePath)
		{
			string inFileName = imagePath;
			System.IO.FileStream inFile;
			byte[] bs;

			inFile = new System.IO.FileStream(inFileName,
				System.IO.FileMode.Open, System.IO.FileAccess.Read);
			bs = new byte[inFile.Length];
			int readBytes = inFile.Read(bs, 0, (int)inFile.Length);
			inFile.Close();

			string base64String;
			base64String = System.Convert.ToBase64String(bs);

			return base64String;
		}
	}
}
