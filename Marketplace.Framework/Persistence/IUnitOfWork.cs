namespace Marketplace.Framework.Persistence;
public interface IUnitOfWork
{
    Task Commit();
}
