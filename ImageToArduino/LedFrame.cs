using System;
using System.Drawing;
using Gifed;

namespace Led
{
	public class LedFrame : LedImage
	{
		public LedFrame(GifFrame frame) : base(frame.Image as Bitmap)
		{
			this.Delay = (uint)frame.Delay.Milliseconds;
		}

		public uint Delay { get; private set; }
	}
}
