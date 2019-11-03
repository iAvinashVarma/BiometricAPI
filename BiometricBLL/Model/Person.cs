using BiometricBLL.Custom.Converter;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BiometricBLL.Model
{
    [XmlRoot("Persons")]
    public class Persons : List<Person> { }

    [MetadataType(typeof(PersonMetaData))]
    public class Person : IEntity
    {
        [JsonProperty(PropertyName = "_id")]
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        [BsonElement("lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "age")]
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

        [JsonProperty(PropertyName = "gender")]
        [BsonElement("gender")]
        public Gender Gender { get; set; }

        [JsonProperty(PropertyName = "dateOfBirth")]
        [BsonElement("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "isRegistered")]
        [BsonElement("isRegistered")]
        public bool IsRegistered { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }

    public class PersonPatch
    {
        public ObjectId Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
    }

    public partial class PersonMetaData
    {
        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Age")]
        public byte Age { get; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Is Registered")]
        public bool IsRegistered { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }

    public enum Gender : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }
}
