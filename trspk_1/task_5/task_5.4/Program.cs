
class Program
{
	class CopyPaste : IDisposable
	{
		public CopyPaste(string fileName1,string fileName2)
		{
			this.fileName1 = fileName1;
			this.fileName2 = fileName2;
		}
		StreamReader file1;
		StreamWriter file2;
		bool _disposed;
		string fileName1;
		string fileName2;

		private void Open()
		{
			file1 = new StreamReader(this.fileName1);
			file2 = new StreamWriter(this.fileName2);
		}

		public void Work()
		{
			Open();
			//file2.Write(file1.ReadToEnd());
			while (!file1.EndOfStream)
			{		
				file2.WriteLine(file1.ReadLine());
			}

			Close();
		}
		private void Close()
		{
			Dispose();
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
			{}
			file1?.Dispose();
			file2?.Dispose();

			_disposed = true;
		}
	}

	static void Main(string[]args)
	{
		var copyPaste = new CopyPaste("file1.txt", "file2.txt");
		copyPaste.Work();
	}
}
