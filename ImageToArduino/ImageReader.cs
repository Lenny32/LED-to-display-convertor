using System;
using System.Drawing;
using Gifed;

namespace Led
{
	public class ImageReader
	{
		
		public static RGB[] Read(Bitmap img)
		{
			var table = new RGB[img.Width * img.Height];

			int i = 0;

			for (int x = 0; x < img.Width; x++)
			{
				//Up
				if (x % 2 == 0)
				{
					for (int y = img.Height - 1; y >= 0; y--)
					{
						var pixel = img.GetPixel(x, y);
						table[i] = new RGB(pixel.R, pixel.G, pixel.B);
						i++;
					}
				}
				//Down
				else
				{
					for (int y = 0; y < img.Height; y++)
					{
						var pixel = img.GetPixel(x, y);
						table[i] = new RGB(pixel.R, pixel.G, pixel.B);
						i++;
					}
				}
			}
			return table;
		}

	}
}
