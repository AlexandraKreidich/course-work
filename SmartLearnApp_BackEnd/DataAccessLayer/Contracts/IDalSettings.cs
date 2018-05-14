using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IDalSettings
    {
        [NotNull]
        string ConnectionString { get; }
    }
}