using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace Led
{
	public class CodeBuilder
	{
		private StringBuilder _code;
		private RGB[][] _tables;
		//private TimeSpan _duration;

		private IEnumerable<LedFrame> _frames;

		private CodeBuilder()
		{
			_code = new StringBuilder();
		}

		public CodeBuilder(RGB[] table):this()
		{
			_tables = new RGB[1][];
			_tables[0] = table;
		}

		public CodeBuilder(IEnumerable<LedFrame> frames): this()
		{
			this._frames = frames;
			//_duration = duration;
		}

		private void GenerateHeader()
		{
			_code.AppendLine("# include <FastLED.h>");
			_code.AppendLine("#define NUM_LEDS 88");
			_code.AppendLine("#define DATA_PIN 12");

			_code.AppendLine("CRGB leds[NUM_LEDS];");
		}

		public string GenerateSimpleImage()
		{
			var table = _tables[0];

			_code.AppendLine("void setup()");
			_code.AppendLine("{");

			_code.AppendLine("\tFastLED.addLeds<WS2812B, DATA_PIN, GRB>(leds, NUM_LEDS);");

			GenerateValues(table);


			_code.AppendLine("\tFastLED.show();");
			_code.AppendLine("}");


			_code.AppendLine("void loop()");
			_code.AppendLine("{");

			_code.AppendLine("}");

			return _code.ToString(); 
		}

		public string GenerateGif()
		{
			GenerateHeader();

			_code.AppendLine("void setup()");
			_code.AppendLine("{");
			_code.AppendLine("\tFastLED.addLeds<WS2812B, DATA_PIN, GRB>(leds, NUM_LEDS);");
			_code.AppendLine("}");




			int imageIndex = 0;
			foreach (var frame in _frames)
			{
				_code.AppendLine($"void image{imageIndex}(){{");
				GenerateValues(frame.RGB);
				_code.AppendLine("}");
				imageIndex++;
			}
			_code.AppendLine("void loop()");
			_code.AppendLine("{");

			imageIndex = 0;
			foreach (var frame in _frames)
			{
				Console.WriteLine(imageIndex);
				_code.AppendLine($"image{imageIndex}();");
				_code.AppendLine($"delay({frame.Delay})");

				imageIndex++;
			}

			_code.AppendLine("}");
			return _code.ToString();

		}

		private void GenerateValues(RGB[] table)
		{
			var index = 0;
			foreach (var pixel in table)
			{
				var text = $"\tleds[{index}].setRGB({pixel.R}, {pixel.G}, {pixel.B});";
				index++;
				_code.AppendLine(text);
			}
		}

	}
}
