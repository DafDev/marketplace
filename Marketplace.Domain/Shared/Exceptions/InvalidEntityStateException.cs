namespace Marketplace.Domain.Shared.Exceptions;
public class InvalidEntityStateException(object entity, string message)
    : Exception($"Entity {entity.GetType().Name} state change denied, {message}")
{ }
