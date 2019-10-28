using BiometricBLL.Concrete;
using BiometricBLL.Model;
using BiometricBLL.Pattern;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BiometricBLL.Pattern.Repository.Json
{
    public class PersonRepository : JsonRepository<Person>
    {
        public PersonRepository() : base(@"Data/Biometric.json")
        {

        }
    }
}
