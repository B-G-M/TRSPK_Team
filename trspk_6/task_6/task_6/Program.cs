using System;
using System.Reflection;

namespace task_6
{
	class NameAttribute : System.Attribute
	{
		public NameAttribute(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public string Name { get; set; }
		public string Description { get; set; }
	}


	class FirstClass
	{
		[Name("First","First Property")]
		public int First { get; set; }

		[Name("Second", "Second Property")]
		public int Second { get; set; }

		[Name("Third", "Third Property")]
		public int Third { get; set; }

		[Name("Fourth ", "Fourth Property")]
		public int Fourth { get; set; }

		[Name("Fifth", "Fifth Property")]
		public int Fifth { get; set; }

		[Name("Sixth ", "Sixth Property")]
		public int Sixth { get; set; }

		[Name("Seventh", "Seventh Property")]
		public int Seventh { get; set; }

		[Name("Eighth", "Eighth Property")]
		public int Eighth { get; set; }

		[Name("Ninth", "Ninth Property")]
		public int Ninth { get; set; }

		[Name("Tehth", "Tehth Property")]
		public int Tehth { get; set; }

	}

	class Program
	{
		static void Main(string[] args)
		{
			Type type = typeof(FirstClass);
			var props = type.GetProperties();
			foreach (var prop in props)
			{
				var attrs = prop.GetCustomAttributes(typeof(NameAttribute),false);
				foreach (NameAttribute attr in attrs)
				{
					Console.WriteLine("Name: {0}, Description: {1} ", attr.Name, attr.Description);
				}
				
			}
		}
	}
}
