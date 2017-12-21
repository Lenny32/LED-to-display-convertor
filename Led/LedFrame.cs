using System;
using System.Drawing;
using Gifed;

namespace Led
{
	public class LedFrame : LedImage
	{
		public LedFrame(GifFrame frame) : base(frame.Image as Bitmap)
		{
			//*10 to convert it to milliseconds instead of hundred of a second.
			this.Delay = frame.Delay * 10;
		}

		public uint Delay { get; private set; }
	}
}
