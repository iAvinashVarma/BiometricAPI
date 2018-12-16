namespace BiometricBLL.Interface
{
	public interface IBiometricService<T> where T : class
	{
		DataModel GetDataModel();
	}

	public enum DataModel : byte
	{
		MSSQL,
		Mongo,
		Xml,
		Json
	}
}