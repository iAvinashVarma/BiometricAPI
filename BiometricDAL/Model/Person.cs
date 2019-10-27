using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BiometricDAL.Model
{
    public class Person
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("age")]
        public byte Age
        {
            get
            {
                DateTime today = DateTime.Now;
                byte age = (byte)(today.Year - DateOfBirth.Year);
                if (DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        [BsonElement("gender")]
        public Gender Gender { get; set; }

        [BsonElement("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("isRegistered")]
        public bool IsRegistered { get; set; }

        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate 
        {
            get
            {
                return DateTime.Now;
            }
        }
    }

    public enum Gender : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }
}
