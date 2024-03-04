namespace Marketplace.Domain.Contexts.Ad.Exceptions;
public class CurrencyNotInUseException(string? message) : Exception(message) { }