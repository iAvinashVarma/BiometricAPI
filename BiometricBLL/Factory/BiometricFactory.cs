using BiometricBLL.Concrete;
using BiometricBLL.Interface;
using BiometricBLL.Models;
using BiometricBLL.Pattern;

namespace BiometricBLL.Factory
{
	public class BiometricFactory : IBiometricFactory
	{
		DataModel _dataModel;

		public BiometricFactory()
		{
			_dataModel = DataModel.Json;
		}

		public IRepository<Person> BiometricOperation
		{
			get
			{
				IRepository<Person> biometricOperation = null;
				switch (_dataModel)
				{
					case DataModel.MSSQL:
						break;

					case DataModel.Mongo:
						break;

					case DataModel.Xml:
						break;

					case DataModel.Json:
						biometricOperation = new JsonBiometricOperation();
						break;

					default:
						break;
				}
				return biometricOperation;
			}
		}
	}
}