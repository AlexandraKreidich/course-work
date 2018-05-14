using AutoMapper;
using BusinessLayer.Models.Card;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;


namespace BusinessLayer
{
    public static class BlMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<DataAccessLayer.StoredProcedureExecutionResult, StoredProcedureExecutionResult>();
            configuration.CreateMap<CardDalModel, CardBlModel>();
        }
    }
}
