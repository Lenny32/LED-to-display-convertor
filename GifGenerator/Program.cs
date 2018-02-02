using System;
using System.Drawing;
using Gifed;

namespace GifGenerator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var img1 = new Bitmap(8, 11);
			var img2 = new Bitmap(8, 11);
			var img3 = new Bitmap(8, 11);
			var img4 = new Bitmap(8, 11);

			SetPixels(img1, Color.Red);
			SetPixels(img2, Color.Blue);
			SetPixels(img3, Color.Orange);
			SetPixels(img4, Color.Green);


			using (var gif = new AnimatedGif(0))
			{
				gif.AddFrame(img1, new TimeSpan(0,0,1));
				gif.AddFrame(img2, new TimeSpan(0, 0, 1));
				gif.AddFrame(img3, new TimeSpan(0, 0, 1));
				gif.AddFrame(img4, new TimeSpan(0, 0, 1));
				gif.Save("test.gif");
			}

		}

		static void SetPixels(Bitmap img, Color color)
		{
			img.SetPixel(0, 0, color);
			img.SetPixel(0, 1, color);
			img.SetPixel(0, 2, color);
			img.SetPixel(0, 3, color);
			img.SetPixel(0, 4, color);
		}
	}
}
