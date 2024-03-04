namespace Marketplace.Domain.Contexts.Ad.Exceptions;
public class InvalidEntityStateException(object entity, string message)
    : Exception($"Entity {entity.GetType().Name} state change denied, {message}") {}
