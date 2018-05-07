using AutoMapper;
using BusinessLayer.Models;
using JetBrains.Annotations;
using WebApi.Models.User;

namespace WebApi
{
    public static class WebApiMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<RegisterUserWebApiModel, RegisterUserBlModel>();
        }
    }
}
