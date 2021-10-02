using System;

namespace task_3_2

{
	class Man
	{
		protected string name;
		protected uint age;

		public virtual uint Age
		{
			get { return age; }
			set { age = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public void Name2(string n, uint a)
		{
			name = n;
			age = a;
		}

		public virtual void Present()
		{
			Console.WriteLine("Человек, " + age + ", " + name);
		}
	}

	class Teenager : Man
	{
		private string school;

		public override uint Age
		{
			get => base.Age;
			set
			{
				if (value < 13)
				{
					age = 13;
					return;
				}
				if (value > 19)
				{
					age = 19;
					return;
				}
				age = value;
			}
		}

		public string School
		{
			get { return school; }
			set { school = value; }
		}

		public void School2(string s, string n, uint a)
		{
			school = s;
			name = n;
			if (a < 13)
				a = 13;
			else if (a > 19)
				a = 19;
			age = a;
		}

		public override void Present()
		{
			Console.WriteLine("Подросток, " + age + ", " + name + ", Место учебы: " + school);
		}
	}

	class Worker : Man
	{
		private string job;

		public override uint Age
		{
			get => base.Age;
			set
			{
				if (value < 16)
				{
					age = 16;
					return;
				}
				if (value > 70)
				{
					age = 70;
					return;
				}
				age = value;
			}
		}

		public string Job
		{
			get { return job; }
			set { job = value; }
		}

		public void Job2(string j, string n, uint a)
		{
			job = j;
			name = n;
			if (a < 16)
				a = 16;
			else if (a > 70)
				a = 70;
			age = a;
		}

		public override void Present()
		{
			Console.WriteLine("Работник, " + age + ", " + name + ", Место работы: " + job + "\n");
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			Man man = new Man { Age = 28, Name = "Виктор" };
			Teenager teenager = new Teenager { Age = 20, Name = "Глеб", School = "Школа №9" };
			Worker worker = new Worker { Age = 10, Name = "Дмитрий", Job = "2d художник" };
			man.Present();
			teenager.Present();
			worker.Present();

			man.Name2("Николай", 25);
			teenager.School2("Школа №2", "Петр", 30);
			worker.Job2("3d художник", "Александр", 46);
			man.Present();
			teenager.Present();
			worker.Present();
		}
	}
}
