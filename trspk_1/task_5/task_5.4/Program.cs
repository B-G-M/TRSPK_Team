
class Program
{
	class CopyPaste : IDisposable
	{
		CopyPaste(string fileName1,string fileName2)
		{
			this.fileName1 = fileName1;
			this.fileName2 = fileName2;
		}
		StreamReader streamReader = new("file1.txt");
		bool _disposed;
		string fileName1;
		string fileName2;

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
			}
			Console.WriteLine("Class1: не управляемые ресурсы");
			_disposed = true;
		}
	}

	static void Main(string[]args)
	{

	}
}
