using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using BiometricBLL.Custom.Converter;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BiometricBLL.Model
{
    [XmlRoot("Users")]
    public class Users : List<User> { }

    [MetadataType(typeof(UserMetaData))]

    public class User : IEntity
    {
        [JsonProperty(PropertyName = "_id")]
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        [BsonElement("email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        [BsonElement("password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }

    public class UserInfo
    {
        [JsonProperty(PropertyName = "_id")]
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        [BsonElement("email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }

    public class UserMetaData
    {
        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
