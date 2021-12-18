
class Program
{
	class ModifyingFile : IDisposable
	{
		public ModifyingFile(string fileName1, string fileName2)
		{
			this.fileName1 = fileName1;
			this.fileName2 = fileName2;
			Open();
		}
		~ModifyingFile()
		{
			Dispose(false);
		}
		StreamReader file1;
		StreamWriter file2;
		bool _disposed;
		string fileName1 { get; set; }
		string fileName2 { get; set; }

		protected void Open()
		{
			file1 = new StreamReader(this.fileName1);
			file2 = new StreamWriter(this.fileName2);
		}

		public void Work(IWork work)
		{
			work.Work(file1, file2);
			Close();
		}
		protected void Close()
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
			{
				file1?.Dispose();
				file2?.Dispose();
			}

			_disposed = true;
		}
	}
	interface IWork
	{
		void Work(StreamReader file1, StreamWriter file2);
	}

	class CopyPasteFile : IWork
	{
		public void Work(StreamReader file1, StreamWriter file2)
		{
			//file2.Write(file1.ReadToEnd());
			while (!file1.EndOfStream)
			{
				file2.WriteLine(file1.ReadLine());
			}
		}
	}


	static void Main(string[] args)
	{
		var copyPaste = new ModifyingFile("file1.txt", "file2.txt");
		copyPaste.Work(new CopyPasteFile());
	}
}
