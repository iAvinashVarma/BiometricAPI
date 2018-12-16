using BiometricBLL.Concrete;
using BiometricBLL.Interface;
using BiometricBLL.Models;

namespace BiometricBLL
{
	public class BiometricFactory
	{
		private readonly DataModel _dataModel;

		public BiometricFactory(DataModel dataModel)
		{
			_dataModel = dataModel;
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

	public enum DataModel : byte
	{
		MSSQL,
		Mongo,
		Xml,
		Json
	}
}