using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataService.Models
{
	public static partial class DefaultExtensions
	{
		public static string ToIgnoreAccentRegex(this string input)
		{
			var newString = new StringBuilder("");
			foreach (var c in input)
			{
				switch (c)
				{
					case 'a':
						newString.Append("[ặẵẳằắăậẫẩầấâạãảàáa]");
					break;
					case 'e':
						newString.Append("[ệễểềếêẹẽẻèée]");
					break;
					case 'y':
						newString.Append("[ỵỹỷỳýy]");
					break;
					case 'u':
						newString.Append("[ựữửừứưụũủùúu]");
					break;
					case 'i':
						newString.Append("[ịĩỉìíi]");
					break;
					case 'o':
						newString.Append("[ợỡởờớơộỗổồốôọõỏòóo]");
					break;
					default:
						newString.Append(c);
					break;
				}
			}
			return newString.ToString();
		}
	}
	
}
