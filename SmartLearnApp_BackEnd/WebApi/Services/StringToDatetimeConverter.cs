using AutoMapper;
using System;
using JetBrains.Annotations;

namespace WebApi.Services
{
    [UsedImplicitly]
    public class StringToDateTimeConverter : ITypeConverter<string, DateTimeOffset>
    {
        public DateTimeOffset Convert(string source, DateTimeOffset destination, ResolutionContext context)
        {
            DateTimeOffset.TryParse(source, out DateTimeOffset dateTimeOffset);

            return dateTimeOffset;
        }
    }
}
