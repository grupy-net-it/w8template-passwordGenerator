using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicPasswordGenerator.Data
{
	public class GeneratorOption
	{
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public int Length { get; set; }
		public bool SmallLetters { get; set; }
		public bool CapitalLetters { get; set; }
		public bool Digits { get; set; }
		public bool SpecialChars { get; set; }

		public GeneratorOption()
		{
		}
	}
}
