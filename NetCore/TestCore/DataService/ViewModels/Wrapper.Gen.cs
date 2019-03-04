using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.ViewModels
{
	public interface IWrapper
	{
		object GetValue();
	}
	
	public class Wrapper<T> : IWrapper
	{
		public T Value { get; set; }
		
		public Wrapper(T value)
		{
			Value = value;
		}
		public Wrapper()
		{
		}
		public object GetValue()
		{
			return Value;
		}
	}
	
}
