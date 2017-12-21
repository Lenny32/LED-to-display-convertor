namespace Led
{
	public class RGB
	{
		public RGB()
		{

		}
		public RGB(int r, int g, int b)
		{
			this.R = r;
			this.G = g;
			this.B = b;
		}
		public int R { get; set; }
		public int G { get; set; }
		public int B { get; set; }
	}
}
