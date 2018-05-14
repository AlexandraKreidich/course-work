using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DalModule
    {
        public static void Register([NotNull] IServiceCollection collection)
        {
            collection.AddSingleton<IUserRepository, UserRepository>();
            collection.AddSingleton<ICardRepository, CardRepository>();
        }
    }
}