﻿using BiometricBLL.Concrete;
using BiometricBLL.Enum;
using BiometricBLL.Model;
using JsonRepo = BiometricBLL.Pattern.Repository.Json;
using MongoRepo = BiometricBLL.Pattern.Repository.Mongo;

namespace BiometricBLL.Pattern.Factory
{
    public static class PersonFactory
    {
        public static IPersonRepository<Person> Repository
        {
            get
            {
                IPersonRepository<Person> repository;
                var connectionType = ConnectionProcess.Instance.ConnectionType;
                switch (connectionType)
                {
                    case ConnectionType.MongoDb:
                        repository = new MongoRepo.PersonRepository();
                        break;
                    case ConnectionType.Json:
                        repository = new JsonRepo.PersonRepository();
                        break;
                    default:
                        repository = new JsonRepo.PersonRepository();
                        break;
                }
                return repository;
            }
        }
    }
}