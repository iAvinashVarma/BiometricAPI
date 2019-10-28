using BiometricBLL.Concrete;
using BiometricBLL.Model;

namespace BiometricBLL.Pattern.Repository.Mongo
{
    public class PersonRepository : MongoRepository<Person>
    {
        public PersonRepository() : base(MongoCredential.Instance.ConnectionString, MongoCredential.DatabaseName, MongoCredential.CollectionName)
        {

        }
    }
}
