using BiometricBLL.Interface;
using BiometricBLL.Models;

namespace BiometricBLL.Factory
{
	public interface IBiometricFactory
	{
		IRepository<Person> BiometricOperation { get; }
	}
}