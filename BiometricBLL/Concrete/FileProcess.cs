using BiometricBLL.Pattern;
using System.IO;

namespace BiometricBLL.Concrete
{
	public class FileProcess : SingletonBase<FileProcess>
	{
		private FileProcess() { }

		public string ReadAllText(string absoluteConnectionString)
		{
			return File.ReadAllText(absoluteConnectionString);
		}

		public void WriteAllText(string absoluteConnectionString, string serialize)
		{
			File.WriteAllText(absoluteConnectionString, serialize);
		}
	}
}
