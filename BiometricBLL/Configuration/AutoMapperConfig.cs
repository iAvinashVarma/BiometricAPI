using AutoMapper;
using BiometricBLL.Model;

namespace BiometricBLL.Configuration
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserInfo>();
            });
        }
    }
}
