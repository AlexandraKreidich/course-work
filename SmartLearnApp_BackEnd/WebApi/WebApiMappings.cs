using AutoMapper;
using BusinessLayer.Models.Card;
using BusinessLayer.Models.Folder;
using BusinessLayer.Models.User;
using JetBrains.Annotations;
using WebApi.Models.Card;
using WebApi.Models.Folder;
using WebApi.Models.User;

namespace WebApi
{
    public static class WebApiMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<RegisterUserWebApiModel, RegisterUserBlModel>();
            configuration.CreateMap<CardWebApiModel, CardBlModel>();
            configuration.CreateMap<CardBlModel, CardWebApiModel>();
            configuration.CreateMap<CardAnswerRequestWebApiModel, CardAnswerRequestBlModel>();
            configuration.CreateMap<FolderResponseBlModel, FolderResponseWebApiModel>();
        }
    }
}
