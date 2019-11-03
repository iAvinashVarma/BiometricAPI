using BiometricBLL.Model;
using BiometricBLL.Pattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiometricBLL.Pattern.Repository.Json
{
    public class PersonRepository : JsonRepository<Person>, IPersonRepository<Person, PersonPatch>
    {
        public PersonRepository() : base(@"Data/Biometric.json")
        {

        }

        public IEnumerable<Person> GetEntitiesByFirstName(string firstName)
        {
            return GetAll().Where(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Person> GetEntitiesByLastName(string lastName)
        {
            return GetAll().Where(p => p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public Person Patch(PersonPatch personPatch)
        {
            var person = GetById(personPatch.Id);
            return person;
        }
    }
}
