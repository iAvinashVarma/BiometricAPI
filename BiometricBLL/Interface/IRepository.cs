using System.Collections.Generic;

namespace BiometricBLL.Interface
{
	public interface IRepository<T> where T : class
	{
		T Create(T entity);

		IEnumerable<T> ReadAll();

		T ReadById(int id);

		T Update(int id, T entity);

		T Delete(int id);
	}
}