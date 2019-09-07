using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataService.Models
{
	public static partial class DefaultExtensions
	{
		public static readonly string[] Fam = new string[]
		{
			"ặẵẳằắăậẫẩầấâạãảàáa",
			"ệễểềếêẹẽẻèée",
			"ỵỹỷỳýy",
			"ựữửừứưụũủùúu",
			"ịĩỉìíi",
			"ợỡởờớơộỗổồốôọõỏòóo",
			"đd"
		};
		public static string ToIgnoreAccentRegex(this string input)
		{
			var newString = new StringBuilder("");
			foreach (var c in input)
			{
				var fam = Fam.FirstOrDefault(f => f.Contains(c));
				if (fam == null)
					newString.Append(c);
				else newString.Append($"[{fam}]");
			}
			return newString.ToString();
		}
	}
	
}
