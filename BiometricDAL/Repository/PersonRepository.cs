using BiometricDAL.Model;
using BiometricDAL.Pattern;

namespace BiometricDAL.Repository
{
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        {

        }
    }
}
