
namespace Domain.Common.Contracts;

public interface IUnitOfWork : IDisposable
{
    IAccountRepository AccountRepository { get; }
    
    ITransactionRepository TransactionRepository { get; }

    IUserRepository UserRepository { get; }
    
    void Save();
    Task SaveAsync();
    Task BeginTransactionAsync();
    Task CommitAsync(bool save = false);
    Task RollbackAsync();
}