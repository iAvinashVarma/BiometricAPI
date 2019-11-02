using MongoDB.Bson;
using System;

namespace BiometricBLL.Model
{
    public interface IEntity
    {
        ObjectId Id { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
