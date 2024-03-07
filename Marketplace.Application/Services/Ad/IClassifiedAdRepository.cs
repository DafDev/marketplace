namespace Marketplace.Application.Services.Ad;

public interface IClassifiedAdRepository
{
    Task<bool> Exists<T>(string id);

    Task<T> Load<T>(string id);
    Task Save<T>(T entity);
}