namespace AntiDotNET.Application.Contracts.Persistence.Common;

public interface IUnitOfWork
{
    Task CommitAsync();
    ValueTask RollBackAsync();
}