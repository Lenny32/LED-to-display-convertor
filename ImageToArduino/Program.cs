using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Gifed;

namespace Led
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			if(args.Length < 1){
				Console.WriteLine("Nothing to do");
			}

			var fileInfo = new System.IO.FileInfo(args[0]);

			if (!fileInfo.Exists)
			{
				Console.WriteLine("Nothing to do! File does not exists");
				return;
			}


			CodeBuilder codeBuilder;
			string code;

			if(fileInfo.Extension.Equals(".gif", StringComparison.InvariantCultureIgnoreCase))
			{
				//multiple images
				using (var gif = AnimatedGif.LoadFrom(fileInfo.FullName))
				{
					Console.WriteLine(gif.FrameCount);
					var frames = gif.Select(x => new LedFrame(x)).ToList();
					Console.WriteLine(frames.Count());

					codeBuilder = new CodeBuilder(frames);
				}
				code = codeBuilder.GenerateGif();
			}
			//Single image
			else
			{
				var img = Image.FromFile(fileInfo.Name) as Bitmap;

				codeBuilder = new CodeBuilder(ImageReader.Read(img));
				code = codeBuilder.GenerateSimpleImage();
			}


		



			System.IO.File.WriteAllText($"{fileInfo.Name}.ino", code.ToString());
		}
	}
}
