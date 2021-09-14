using System;

namespace task1_2
{
	class Human
	{
		public Human(string name, string surname)
		{
			this.surname = surname;//Поля для чтения можно инициализировать в конструкторе
			//this.name = name; Константы должны быть инициализированны при определении
		}
		const string name = "Василий";
		readonly string surname = "Тёмный";
		private int age = 20;

		public string Name
		{
			get { return name; }
			//set { myVar = value; }
		}
		public string Surname
		{
			get { return surname; }
			//set { surname = value; } - Поля разрешенные только
			//для чтения можно инициализировать при их объявлении
			//либо на уровне класса, либо инициилизировать и изменять
			//в конструкторе. Инициализировать или изменять их значение
			//в других местах нельзя. 
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}


	}




	class Program
	{
		static void Main(string[] args)
		{
			Human H = new Human("Валерий","Соколов");
			Console.WriteLine("Age: " + H.Age);
			Console.WriteLine("Surname: " + H.Surname);
			H.Age = 31;
			Console.WriteLine("Age: " + H.Age);
		}
	}
}
