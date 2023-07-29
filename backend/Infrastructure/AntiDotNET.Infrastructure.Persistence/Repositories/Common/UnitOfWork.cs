using AntiDotNET.Application.Contracts.Persistence.Common;

namespace AntiDotNET.Infrastructure.Persistence.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    public Task CommitAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask RollBackAsync()
    {
        throw new NotImplementedException();
    }
}