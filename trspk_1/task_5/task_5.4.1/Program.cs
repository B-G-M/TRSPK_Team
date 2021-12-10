
class Program
{
	abstract class ModifyingFile : IDisposable
	{
		public ModifyingFile(string fileName1, string fileName2)
		{
			this.fileName1 = fileName1;
			this.fileName2 = fileName2;
		}

		protected StreamReader file1;
		protected StreamWriter file2;
		protected bool _disposed;
		protected string fileName1 { get; set; }
		protected string fileName2 { get; set; }

		protected void Open()
		{
			file1 = new StreamReader(this.fileName1);
			file2 = new StreamWriter(this.fileName2);
		}

		public abstract void Work();

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
			{ }
			file1?.Dispose();
			file2?.Dispose();

			_disposed = true;
		}
	}


	class CopyPaste : ModifyingFile
	{
		public CopyPaste(string fileName1, string fileName2) : base(fileName1, fileName2)
		{}

		public override void Work()
		{
			Open();
			//file2.Write(file1.ReadToEnd());
			while (!file1.EndOfStream)
			{
				file2.WriteLine(file1.ReadLine());
			}
			Close();
		}
	}


	static void Main(string[] args)
	{
		ModifyingFile copyPaste = new CopyPaste("file1.txt", "file2.txt");
		copyPaste.Work();
	}
}
