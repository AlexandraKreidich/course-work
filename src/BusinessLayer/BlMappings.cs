using AutoMapper;
using JetBrains.Annotations;


namespace BusinessLayer
{
    public static class BlMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<DataAccessLayer.StoredProcedureExecutionResult, StoredProcedureExecutionResult>();
        }
    }
}
