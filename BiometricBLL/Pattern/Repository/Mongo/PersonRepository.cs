using System.Collections.Generic;
using BiometricBLL.Concrete;
using BiometricBLL.Model;
using BiometricBLL.Pattern.Interface;
using MongoDB.Driver;

namespace BiometricBLL.Pattern.Repository.Mongo
{
    public class PersonRepository : MongoRepository<Person>, IPersonRepository<Person, PersonPatch>
    {
        public PersonRepository() : base(DatabaseCredential.Instance.ConnectionString, DatabaseCredential.DatabaseName, DatabaseCredential.PersonCollectionName)
        {

        }

        public IEnumerable<Person> GetEntitiesByFirstName(string firstName)
        {
            var filter = Builders<Person>.Filter.Eq(u => u.FirstName, firstName);
            var result = _mongoCollection.Find(filter).ToList();
            return result;
        }

        public IEnumerable<Person> GetEntitiesByLastName(string lastName)
        {
            var filter = Builders<Person>.Filter.Eq(u => u.LastName, lastName);
            var result = _mongoCollection.Find(filter).ToList();
            return result;
        }

        public Person Patch(PersonPatch patch)
        {
            var filter = Builders<Person>.Filter.Eq(u => u.Id, patch.Id);
            var result = _mongoCollection.Find(filter).SingleOrDefault();
            _mongoCollection.InsertOne(result);
            return result;
        }
    }
}
