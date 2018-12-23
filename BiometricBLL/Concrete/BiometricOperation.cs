using BiometricBLL.Interface;
using BiometricBLL.Models;
using BiometricBLL.Pattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BiometricBLL.Concrete
{
	public abstract class BiometricOperation : IRepository<Person>
	{
		public virtual string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		public abstract IEnumerable<Person> ReadAll();

		public virtual Person ReadById(int id)
		{
			return ReadAll().FirstOrDefault(p => p.Id == id);
		}

		public abstract Person Create(Person entity);

		public abstract Person Delete(int id);

		public abstract Person Update(int id, Person entity);
	}
}