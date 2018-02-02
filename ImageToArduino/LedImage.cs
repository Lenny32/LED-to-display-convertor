using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Led
{
	public class LedImage
	{
		private List<RGB> _rgb;

		protected LedImage()
		{
			_rgb = new List<RGB>();
		}

		public LedImage(Bitmap img) : this()
		{
			_rgb = ImageReader.Read(img).ToList();
		}



		public RGB GetLed(int position)
		{
			return null;
		}
		public void SetLed(int position, RGB rgb)
		{
			_rgb.RemoveAt(position);
			_rgb.Insert(position, rgb);
		}

		public RGB[] RGB => this._rgb.ToArray();
	}
}
