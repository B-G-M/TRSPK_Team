using System.Runtime.InteropServices;

class Program
{
	class Class1 : IDisposable
	{
		Class2 class2 = new Class2();
		bool _disposed;

		~Class1()
		{
			Console.WriteLine("Class1: ~Class1()");
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				Console.WriteLine("Class1: управляемые ресурсы");
				class2.Dispose();
			}
			Console.WriteLine("Class1: не управляемые ресурсы");
			_disposed = true;
		}

	}

	class Class2 : IDisposable
	{
		//Class1 class1 = new Class1();
		bool _disposed;

		~Class2()
		{
			Console.WriteLine("Class2: ~Class2()");
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				Console.WriteLine("Class2: управляемые ресурсы");
				//class1.Dispose();
			}
			Console.WriteLine("Class2: не управляемые ресурсы");
			_disposed = true;
		}
	}

	static void Main(string[] args)
	{
		Class1 class1 = new Class1();
		class1.Dispose();
		GC.Collect();
	}
}

