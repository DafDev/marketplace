using Marketplace.Framework.Persistence;
using Raven.Client.Documents.Session;

namespace Marketplace.Infrastructure;
public class RavenDbUnitOfWork(IAsyncDocumentSession session) : IUnitOfWork
{
    private readonly IAsyncDocumentSession _session = session;

    public Task Commit() => _session.SaveChangesAsync();
}
