using System.Collections.Generic;
using BiometricBLL.Concrete;
using BiometricBLL.Model;
using MongoDB.Driver;

namespace BiometricBLL.Pattern.Repository.Mongo
{
    public class PersonRepository : MongoRepository<Person>, IPersonRepository<Person>
    {
        public PersonRepository() : base(DatabaseCredential.Instance.ConnectionString, DatabaseCredential.DatabaseName, DatabaseCredential.CollectionName)
        {

        }

        public IEnumerable<Person> GetEntitiesByFirstName(string firstName)
        {
            var filter = Builders<Person>.Filter.Eq("firstName", firstName);
            var result = _mongoCollection.Find(filter).ToList();
            return result;
        }

        public IEnumerable<Person> GetEntitiesByLastName(string lastName)
        {
            var filter = Builders<Person>.Filter.Eq("lastName", lastName);
            var result = _mongoCollection.Find(filter).ToList();
            return result;
        }
    }
}
