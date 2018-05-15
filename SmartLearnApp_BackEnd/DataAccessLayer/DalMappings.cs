using AutoMapper;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer
{
    public static class DalMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserResponseDalModel>();
            configuration.CreateMap<Folder, FolderDalModel>();
            configuration.CreateMap<Card, CardDalModel>();
        }
    }
}