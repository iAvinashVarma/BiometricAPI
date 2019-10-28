using System;

namespace BiometricBLL.Model
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
